using UniversityProgram.Api.Exceptions.HttpException;

namespace UniversityProgram.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (HttpException hex)
            {
                context.Response.StatusCode = (int)hex.StatusCode;
                await context.Response.WriteAsJsonAsync(new { Message = hex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new { Message = ex.Message, InnerMessage = ex.InnerException!.Message });
            }
        }
    }
}

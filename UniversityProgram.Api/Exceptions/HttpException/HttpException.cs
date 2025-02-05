using System.Net;

namespace UniversityProgram.Api.Exceptions.HttpException
{
    public class HttpException : Exception 
    {
        public HttpStatusCode StatusCode { get; }

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

﻿using NewApi.Services;

namespace NewApi.Middlewares
{
    public class StudentMiddleware
    {
        private RequestDelegate _next;
        private ITestServiceScoped? scoped;
        private readonly ITestServiceTransient transient;
        private readonly ITestServiceSingleton singleton;

        public StudentMiddleware(RequestDelegate next,
            ITestServiceTransient transient,
            ITestServiceSingleton singleton)
        {
            _next = next;
            this.transient = transient;
            this.singleton = singleton;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            this.scoped = context.RequestServices.GetService<ITestServiceScoped>();
            var a = singleton.Test();
            var b = transient.Test();
            var c = scoped?.Test();

            await _next.Invoke(context);
        }
    }
}

namespace NewApi.Startups
{
    public static class Extenstions
    {
        public static void UseMyMiddleWare(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/error")
                {
                    throw new Exception("Error");
                }
                await next();
            });

        }
    }
}

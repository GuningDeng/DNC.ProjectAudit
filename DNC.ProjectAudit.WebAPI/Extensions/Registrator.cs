using DNC.ProjectAudit.WebAPI.Middleware;

namespace DNC.ProjectAudit.WebAPI.Extensions
{
    public static class Registrator
    {
        //public static IApplicationBuilder UseErroHandlingMiddleware (this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ExceptionHandlingMiddleware>();
        //    return app;
        //}

        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }

    }
}

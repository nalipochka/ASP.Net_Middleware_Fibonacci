using ASP_Middleware_Fibonacci.Middleware;

namespace ASP_Middleware_Fibonacci.Utils
{
    public static class MiddlewareExtentions
    {
       public static IApplicationBuilder UseMyErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlingMiddleware>();
        }
        public static IApplicationBuilder UseMyRoutingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RoutingMiddleware>();
        }
    }
}

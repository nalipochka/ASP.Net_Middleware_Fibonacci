using ASP_Middleware_Fibonacci.Middleware;
using ASP_Middleware_Fibonacci.Utils;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//app.UseMiddleware<ErrorHandlingMiddleware>();
//app.UseMiddleware<RoutingMiddleware>();

app.UseMyErrorHandlingMiddleware();
app.UseMyRoutingMiddleware();

app.Run();

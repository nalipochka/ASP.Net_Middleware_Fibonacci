namespace ASP_Middleware_Fibonacci.Middleware
{

    public class RoutingMiddleware
    {
        private readonly RequestDelegate next;

        public RoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? path = context.Request.Path.Value?.ToLower();
            string value = context.Request.Query["index"];
            string token = context.Request.Query["token"];
            if (path == "/fibonacci")
            {
                if (token == "mazurok")
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("<h2 style='color: green;'>" +
                        "Web application for counting fibonacci numbers</h2>");
                    if (value != null)
                    {
                        int index = int.Parse(value);
                        if (index >= 0 && index <= 40)
                        {
                            await context.Response.WriteAsync($"<h1 style='color: pink'>F({index}) = {Fibonacci(index)}</h1>");
                        }
                        else
                        {
                            context.Response.StatusCode = 405;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 405;
                    }
                }
                else
                {
                    context.Response.StatusCode = 403;
                }
            }
            else
            {
                context.Response.StatusCode = 406;
            }
        }
        private static long Fibonacci(int index)
        {
            long[] arr = new long[40];
            arr[0] = 0;
            arr[1] = 1;
            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            if(index == 0)
            {
                return arr[0];
            }
            else if(index == 1)
            {
                return arr[1];
            }
            else
            {
                return arr[index-1];
            }
            
        }
    }
}

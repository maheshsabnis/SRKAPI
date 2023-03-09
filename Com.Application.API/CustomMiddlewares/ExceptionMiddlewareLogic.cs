using System.Runtime.CompilerServices;

namespace Com.Application.API.CustomMiddlewares
{
    /// <summary>
    /// The class thatwill contain properties
    /// used to send error response from API
    /// </summary>
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public int ErrorSeverity { get; set; }
    }

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // If No Error Move to Next Middleware in Pipeline
                await _next(ctx);
            }
            catch (Exception ex)
            {

                
                 // if Error Occures the Handler it and generate response
                 // 1. Set the Status code for response
                 ctx.Response.StatusCode = 500;
                 // 2. Set the Error Object
                 ErrorResponse response = new ErrorResponse() 
                 {
                    StatusCode = ctx.Response.StatusCode,
                    ErrorMessage = ex.Message,
                    ErrorDateTime = DateTime.Now,
                    ErrorSeverity = 5
                 };

                // 3. Send the Response against tehe Current Request
                // Processed in HttpPipeline

                await ctx.Response.WriteAsJsonAsync(response);
            }
        }
    }

    public static class ErrorMiddlewareExtension
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}

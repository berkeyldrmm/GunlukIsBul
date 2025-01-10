using System.Text.Json;

namespace GunlukIsBul.Middlewares
{
    public class CustomExcpetionMiddleware
    {
        private RequestDelegate _next;

        public CustomExcpetionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = e.Message
                }));
            }
        }
    }
}

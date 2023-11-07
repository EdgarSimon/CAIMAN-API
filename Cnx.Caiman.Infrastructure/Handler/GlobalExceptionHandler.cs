using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Cnx.Caiman.Infrastructure.Handler
{
    public static class GlobalExceptionHandler 
    {
        public static async Task  ExcepctionHandler(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            var validation = new
            {
                status = 400,
                title = "Badrequest",
                detail = exception.Message + " " + exception.StackTrace,
                type = string.Format("{0}.{1}.{2}.{3}",
                "Middlewere",
                context.Request.Method,
                "ErrorMessage",
                context.GetType().Name)
            };

            var json = new
            {
                errors = new[] { validation }
            };

            var result = JsonConvert.SerializeObject(json);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
        
    }
}

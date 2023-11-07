using System.Linq;
using System.Net;
using Cnx.Caiman.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Cnx.Caiman.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> logger;
        private readonly IHttpContextAccessor httpcontext;
        private readonly ILogErrorService logService;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IHttpContextAccessor httpcontext, ILogErrorService logService)
        {
            this.logger = logger;
            this.httpcontext = httpcontext;
            this.logService = logService;
        }

        public void OnException(ExceptionContext context)
        {
            this.LogInsert(context);
            var exception = context.Exception;
            logger.LogError(exception.Message);
            var validation = new
            {
                Status = 400,
                Title = "Badrequest",
                Detail = exception.Message,
                StackTrace = exception.StackTrace,
                Type = string.Format("{0}.{1}.{2}.{3}",
                context.ActionDescriptor.GetType().GetProperty("ControllerName").GetValue(context.ActionDescriptor),
                context.HttpContext.Request.Method,
                "ErrorMessage",
                context.Exception.GetType().Name)
            };

            var json = new
            {
                errors = new[] { validation }
            };



            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.ExceptionHandled = true;
        }

        public void LogInsert(ExceptionContext exception)
        {
            var typeExepcion =new string[] { "BusinessException", "CreateValidationException", "DuplicateException" };

            if (!typeExepcion.Any(k => k == exception.Exception.GetType().Name))
            {
                var action = exception.ActionDescriptor.GetType().GetProperty("ControllerName").GetValue(exception.ActionDescriptor);
                var len = exception.Exception.Message.Length > 8000 ? 8000 : exception.Exception.Message.Length - 1;
                var message = exception.Exception.Message.Substring(0, len);
                var lenTrace = exception.Exception.StackTrace.Length > 8000 ? 8000 : exception.Exception.StackTrace.Length - 1;
                var trace = exception.Exception.StackTrace.Substring(0, lenTrace);
                var mail = this.httpcontext.HttpContext.User.Identity.Name;
                this.logService.InsertLog(action.ToString(), message, mail, trace).Wait();
            }
        }
    }
}
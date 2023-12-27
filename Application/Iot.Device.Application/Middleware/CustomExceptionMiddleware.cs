using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; 
using System;
using System.Net;
using System.Threading.Tasks;

namespace Iot.Device.Application.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<CustomExceptionMiddleware> logger)
        {
            int code;
            var result = exception.Message;

            switch (exception)
            {
                case Exceptions.ValidationException validationException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case Exceptions.BadRequestException badRequestException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case Exceptions.DeleteFailureException deleteFailureException:
                    code = (int)HttpStatusCode.BadRequest;
                    result = deleteFailureException.Message;
                    break;
                case Exceptions.NotFoundException _:
                    code = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    code = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            logger.LogError(result);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { StatusCode = code, ErrorMessage = exception.Message }));
        }
    }

}

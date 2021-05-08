using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Nairobi.Dtos.Core;

namespace Nairobi.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.Message, context.Exception);

            List<ServiceResult> sr = new List<ServiceResult>();
            if (context.Exception is ValidationException validationException)
            {
                foreach (var error in validationException.Errors)
                {
                    sr.Add(new ServiceResult(error.ErrorMessage,error.PropertyName));
                }

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new JsonResult(sr);
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                sr.Add(new ServiceResult("Sistemsel bir hata oluştu", "500"));
                context.Result = new JsonResult(sr);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sam.CarInfo.Filters
{
    public class SamExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<SamExceptionFilter> _logger;
        public SamExceptionFilter(ILogger<SamExceptionFilter> _logger)
        {
            this._logger = _logger;
        }
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            var message = context.Exception.Message;
            context.ExceptionHandled = true;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";


            //SamToDo, global logging error can be done here
            var responseMsg = "Something just happened: " + message + "|" + context.Exception.StackTrace;
            _logger.LogWarning(responseMsg);
            //End of SamToDo

            response.WriteAsync(JsonConvert.SerializeObject(responseMsg));
        }
    }
}

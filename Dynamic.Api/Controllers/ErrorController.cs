namespace Dynamic.Api.Controllers
{
    using Dynamic.Core.ViewModels;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Net;

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private ILogger<ErrorsController> logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this.logger = logger;
        }
        
        [Route("error")]
        public ErrorViewModel Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            Response.StatusCode = (int)GetErrorCode(exception); 
            
            return new ErrorViewModel(exception);
        }

        private HttpStatusCode GetErrorCode(Exception ex)
        {
            switch (ex)
            {
                case ArgumentNullException:
                    return HttpStatusCode.BadRequest;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}

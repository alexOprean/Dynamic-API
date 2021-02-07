namespace Dynamic.Api.ActionFilters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;

    public class PerformanceFilter : IActionFilter
    {
        private ILogger<PerformanceFilter> logger;
        private Stopwatch watch;
        public PerformanceFilter(ILogger<PerformanceFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            watch.Stop();
            logger.LogInformation($"Finished Execution from " +
                $"{filterContext.ActionDescriptor.DisplayName} in {watch.ElapsedMilliseconds} miliseconds");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logger.LogInformation($"Started Execution from {filterContext.ActionDescriptor.DisplayName}");
            watch = Stopwatch.StartNew();
        }
    }
}

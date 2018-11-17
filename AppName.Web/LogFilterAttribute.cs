using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;

        private static Logger _logger =
            LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();
            _logger.Info($"Request: {filterContext.HttpContext.Request.Url.AbsolutePath}: {_stopwatch.ElapsedMilliseconds}");
        }
    }
}
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AprilBookStore.Controllers
{
    public class ErrorController : Controller
    {
        public ILogger<ErrorController> _logger { get; set; }
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{statusCode}")]

        public IActionResult HttpStatusCodeHandler(int statusCode) 
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode){
                case 404:
                    ViewBag.ErrorMessage="Not Found";
                    ViewBag.StatusCode=statusCode;
                    _logger.LogWarning($" 404 error path  {statusCodeResult.OriginalPath} query {statusCodeResult.OriginalQueryString}");
                    break;
                default:
                    ViewBag.StatusCode=statusCode;
                    break;
            }

            return View("NotFound");
        }
        public IActionResult Error()
        {
            var exeptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exeptionDetails.Path;
            ViewBag.ExceptionMessage = exeptionDetails.Error.Message;
            ViewBag.StackTrace = exeptionDetails.Error.StackTrace;
            _logger.LogError($"The path {exeptionDetails.Path} thre an exception {exeptionDetails.Error}");

            return View("Error");
        }
    }
}

using ErrorOr;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RestaurantDDD.API.Controllers
{

    [Route("error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet , HttpPost]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Problem(
                title: exception?.Message,
                detail:
                exception?.Source
                );
        }
    }
}

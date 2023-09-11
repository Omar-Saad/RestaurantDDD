using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantDDD.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DinnersController : ApiController
    {
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}

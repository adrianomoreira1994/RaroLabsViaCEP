using Microsoft.AspNetCore.Mvc;

namespace RaroLabs.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int cep)
        {
            return StatusCode(200, new
            {
                Message = "Api is running"
            });
        }
    }
}

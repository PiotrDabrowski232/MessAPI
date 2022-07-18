using Microsoft.AspNetCore.Mvc;

namespace MessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello world!!!!");
        }
        [HttpPost]
        public IActionResult Post(MessaClass payment)
        {
            return Ok(payment);
        }
    }
}

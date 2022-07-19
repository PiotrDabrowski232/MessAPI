using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace MessAPI.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class MessController : ControllerBase
    {
        private readonly MessService _logger;

        public MessController(ILogger<MessController> logger)
        {
            _logger = new MessService();
        }

        [HttpGet]
        public IEnumerable<MessaClass> Get()
        {
            return _logger.Get();
        }
        [HttpPost]
        public ActionResult<IEnumerable<MessaClass>> Post([FromQuery] string addTitle, [FromQuery] string addBody)
        {
            return Ok(_logger.Post(addTitle, addBody));
        }

    }
}

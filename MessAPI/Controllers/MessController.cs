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
        [Route("mess/{id}")]
        [HttpGet]
        public IEnumerable<MessaClass> Get([FromRoute] int id)
        {

            return _logger.Get(id);
        }
        [HttpPost]
        public ActionResult<IEnumerable<MessaClass>> Post([FromQuery] string addTitle, [FromQuery] string addBody)
        {
            return Ok(_logger.Post(addTitle, addBody));
        }
        [Route("/{id}/{titleToChange}")]
        [HttpPut]
        public ActionResult<IEnumerable<MessaClass>> Put2([FromRoute]int id, [FromRoute] string titleToChange)
        {
            return Ok(_logger.Put(id, titleToChange));
        }

        [Route("/{id}")]
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<MessaClass>> Delete([FromRoute] int id)
        {
            return Ok(_logger.Delete(id));
        }
    }
}

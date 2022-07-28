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
    public class MessageController : ControllerBase
    {
        private readonly MessageService _service;

        public MessageController(ILogger<MessageController> service)
        {
            _service = new MessageService();
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {

            return _service.Get();
        }
       
        [HttpPost]
        public ActionResult<IEnumerable<Message>> Post([FromQuery] string addTitle, [FromQuery] string addBody)
        {
            return Ok(_service.Post(addTitle, addBody));
        }
         /*[Route("mess/{id}")]
        [HttpGet]
        public IEnumerable<MessaClass> Get([FromRoute] int id)
        {

            return _logger.Get(id);
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
        }*/
    }
}

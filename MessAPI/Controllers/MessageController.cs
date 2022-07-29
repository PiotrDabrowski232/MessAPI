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

        [HttpPut]
        public ActionResult<IEnumerable<Message>> Put([FromQuery] int id, [FromQuery] string titleToChange)
        {
            return Ok(_service.Put(id, titleToChange));
        }

        [HttpDelete]
        public ActionResult<IEnumerable<Message>> Delete([FromQuery] int id)
        {
            return Ok(_service.Delete(id));
        }
    }
}


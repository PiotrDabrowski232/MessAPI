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
        private readonly IMessageRepository _service;
        public MessageController(IMessageRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Message> Get()
        {
            return _service.ShowAllMessages();
        }
        
        [HttpPost]
        public ActionResult<IEnumerable<Message>> Post([FromBody] Message message)
        {
            return Ok(_service.AddMessage(message));
        }
        
        [HttpPut]
        public ActionResult<IEnumerable<Message>> Put2([FromBody] Message message)
        {
            return Ok(_service.ChangeMessage(message));
        }

        
        [HttpDelete]
        public ActionResult<IEnumerable<Message>> Delete([FromQuery] int id)
        {
            return Ok(_service.DeleteMessage(id));
        }
    }
}


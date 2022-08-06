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
        public ActionResult<IEnumerable<Message>> Post([FromBody] string addTitle, [FromBody] string addBody)
        {
            return Ok(_service.AddMessage(addTitle, addBody));
        }


        [HttpPut]
        public ActionResult<IEnumerable<Message>> Put([FromQuery] int id, [FromBody] string titleToChange)
        {
            return Ok(_service.ChangeTitle(id, titleToChange));
        }


        [HttpDelete]
        public ActionResult<IEnumerable<Message>> Delete([FromQuery] int id)
        {
            return Ok(_service.DeleteMessage(id));
        }
    }
}


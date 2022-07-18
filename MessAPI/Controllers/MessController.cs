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

        public string[] MessTitles = new[]
        {
            "tytul1", "tytul2", "tytul3", "tytul4", "tytul5"
        };
        public string[] MessBody = new[]
        {
            "tresc1", "tresc2", "tresc3", "tresc4", "tresc5"
        };
       
       /* private readonly ILogger<MessController> _logger;

        public MessController(ILogger<MessController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public IEnumerable<MessaClass> Get()
        {
            int indexerT = MessTitles.Length;
            int indexerB = MessBody.Length;
            return Enumerable.Range(1, 5).Select(index => new MessaClass
            {
                MessClassTitles = MessTitles[--indexerT],
                MessClassBody = MessBody[--indexerB]
            }).ToArray();
            
        }
       
        [HttpPost]
        public IActionResult Post(MessaClass payment)
        {
            
        }
    }
}

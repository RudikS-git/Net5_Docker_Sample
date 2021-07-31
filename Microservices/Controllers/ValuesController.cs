using Microservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public ValuesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] string payload)
        {
            return Ok(_messageService.Enqueue(payload));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("test response");
        }
    }
}
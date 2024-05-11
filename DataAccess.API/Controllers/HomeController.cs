using MessageBrokerClient.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccess.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IMessageSender messageSender) : ControllerBase
    {
        private readonly IMessageSender _messageSender = messageSender;

        [HttpPost("SendMessage")]
        public IActionResult SendMessage()
        {
            _messageSender.SendMessage();
            return Ok();
        }
    }
}

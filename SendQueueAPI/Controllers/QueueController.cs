using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendQueueAPI.Services;

namespace SendQueueAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class QueueController : Controller
    {
        private readonly ISendMessage _serviceSend;
        public QueueController(ISendMessage serviceSend)
        {
            _serviceSend = serviceSend;
        }
        [Route("sendmessage")]
        [HttpPost]
        public IActionResult SendMessage([FromBody] object body)
        {
            _serviceSend.SendMessageQueue(body);
            return Ok();
        }
    }
}

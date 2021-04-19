using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueueRabbitMQ.Model;
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

        [Route("createpatient")]
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientInfo patient)
        {
            await _serviceSend.CreatePatientAsync(patient);
            return Ok();
        }

        [Route("updatepatient")]
        [HttpPost]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientInfo patient)
        {
            await _serviceSend.UpdatePatientAsync(patient);
            return Ok();
        }
    }
}

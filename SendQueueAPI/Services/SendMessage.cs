using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using QueueRabbitMQ;
using QueueRabbitMQ.Model;
using SendQueueAPI.Settings;

namespace SendQueueAPI.Services
{
    public class SendMessage: ISendMessage
    {
        private readonly IRabbitQueue _rabbitQueue;
        private readonly List<ListQueue> _queues;
        public SendMessage(IRabbitQueue rabbitQueue, IOptions<List<ListQueue>> queues)
        {
            _rabbitQueue = rabbitQueue;
            _queues = queues.Value;
        }

        public async Task CreatePatientAsync(PatientInfo patient)
        {
            var apiUrls = _queues.FindAll(x => x.QueueName != patient.QueueName);
            foreach (var queueName in _queues)
            {
                await _rabbitQueue.SendMessageAsync(queueName.ToString(), patient, Constant.CreatePatient);
            }
        }

        public async Task UpdatePatientAsync(PatientInfo patient)
        {
            var apiUrls = _queues.FindAll(x => x.QueueName != patient.QueueName);
            foreach (var queueName in _queues)
            {
               await _rabbitQueue.SendMessageAsync(queueName.ToString(), patient, Constant.UpdatePatient);
            }
        }
    }
}

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
        private readonly List<ApiUrl> _apiUrls;
        public SendMessage(IRabbitQueue rabbitQueue, IOptions<List<ApiUrl>> apiUrls)
        {
            _rabbitQueue = rabbitQueue;
            _apiUrls = apiUrls.Value;
        }

        public async Task CreatePatientAsync(PatientInfo patient)
        {
            var apiUrls = _apiUrls.FindAll(x => x.ApiName != patient.ApiName);
            foreach (var apiname in _apiUrls)
            {
                await _rabbitQueue.SendMessageAsync("queuename", patient, apiname.ApiName.ToString(), Constant.CreatePatient);
            }
        }

        public async Task UpdatePatientAsync(PatientInfo patient)
        {
            var apiUrls = _apiUrls.FindAll(x => x.ApiName != patient.ApiName);
            foreach (var apiname in _apiUrls)
            {
               await _rabbitQueue.SendMessageAsync("queuename", patient, apiname.ApiName.ToString(), Constant.UpdatePatient);
            }
        }
    }
}

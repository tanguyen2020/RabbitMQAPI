using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using QueueRabbitMQ;
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

        public void SendMessageQueue(object body)
        {
            foreach(var apiname in _apiUrls)
            {
                _rabbitQueue.SendMessage("queuename", body, apiname.ApiName.ToString(), "url");
            }
        }
    }
}

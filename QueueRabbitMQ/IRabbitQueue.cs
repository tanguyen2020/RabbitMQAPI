using System;
using System.Threading.Tasks;

namespace QueueRabbitMQ
{
    public interface IRabbitQueue: IDisposable
    {
        void SendMessage(string queuename, object body, string url);
        Task SendMessageAsync(string queuename, object body, string url);
    }
}

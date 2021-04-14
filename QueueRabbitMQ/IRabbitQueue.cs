using System;

namespace QueueRabbitMQ
{
    public interface IRabbitQueue: IDisposable
    {
        void SendMessage(string queuename, object body, string apiname, string url);
    }
}

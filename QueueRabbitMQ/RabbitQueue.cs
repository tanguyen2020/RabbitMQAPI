using RabbitMQ.Client;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QueueRabbitMQ
{
    public class RabbitQueue : IRabbitQueue
    {
        private IConnection _connectionRabbit;
        public RabbitQueue()
        {
        }

        private IConnection CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                return _connectionRabbit = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create connection: {ex.Message}");
            }
        }

        public bool ConnectionExists()
        {
            if (_connectionRabbit != null) return true;
            CreateConnection();
            return _connectionRabbit.IsOpen;
        }

        public void SendMessage(string queuename, object body, string url)
        {
            SendMessageAsync(queuename, body, url).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task SendMessageAsync(string queuename, object body, string url)
        {
            if (!ConnectionExists()) CreateConnection();
            using (var chanel = _connectionRabbit.CreateModel())
            {
                chanel.QueueDeclare(queue: queuename, durable: false, exclusive: false, autoDelete: false, arguments: null);
                chanel.BasicPublish(string.Empty, queuename, null, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body)));
            }
        }

        protected bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _connectionRabbit.Dispose();
            }
            _disposed = true;
        }
        ~RabbitQueue() => Dispose(false);
    }
}

﻿using RabbitMQ.Client;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

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
        public void SendMessage(string queuename, object body, string apiname, string url)
        {
            if (!ConnectionExists()) CreateConnection();
            using (var chanel = _connectionRabbit.CreateModel())
            {
                chanel.QueueDeclare(queue: queuename, durable: false, exclusive: false, autoDelete: false, arguments: null);
                chanel.BasicPublish(exchange: "", routingKey: queuename, basicProperties: null, body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body)));

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(apiname);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body, Formatting.None), Encoding.UTF8, "application/json");
                httpClient.SendAsync(httpRequest);
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

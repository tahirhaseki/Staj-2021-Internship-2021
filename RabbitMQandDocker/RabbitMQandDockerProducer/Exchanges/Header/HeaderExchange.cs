using RabbitMQ.Client;
using RabbitMQandDockerProducer.Helpers;
using RabbitMQandDockerProducer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer.Exchanges.Header
{
    public class HeaderExchange : IExchangeFactory
    {
        public const string EXCHANGE_NAME = "header-exchange";
        public const string QUEUE_NAME_1 = "header-queue-1";
        public const string QUEUE_NAME_2 = "header-queue-2";
        public const string QUEUE_NAME_3 = "header-queue-3";

        public void CreateExchangeAndQueue()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Headers, true);
            var map1 = new Dictionary<string, object>();
            map1.Add("x-match", "any");
            map1.Add("First", "A");
            map1.Add("Fourth", "D");
            // Firs Queue
            channel.QueueDeclare(QUEUE_NAME_1, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_1, EXCHANGE_NAME, "", map1);

            var map2 = new Dictionary<string, object>();
            map2.Add("x-match", "any");
            map2.Add("Fourth", "D");
            map2.Add("Third", "C");
            // Second Queue
            channel.QueueDeclare(QUEUE_NAME_2, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_2, EXCHANGE_NAME, "", map2);

            var map3 = new Dictionary<string, object>();
            map3.Add("x-match", "all");
            map3.Add("First", "A");
            map3.Add("Third", "C");
            // Third Queue
            channel.QueueDeclare(QUEUE_NAME_3, true, false, false, null);
            channel.QueueBind(QUEUE_NAME_3, EXCHANGE_NAME, "", map3);
        }
    }
}

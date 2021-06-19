using RabbitMQ.Client;
using RabbitMQandDockerProducer.Helpers;
using RabbitMQandDockerProducer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer.Exchanges.Fanout
{
    public class FanoutMessage : ISendMessage
    {
        public string Message1 => "First Fanout Message";
        public string Message2 => "Second Fanout Message";
        public string Message3 => "Third Fanout Message";

        public void SendMessage()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();

            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message1.GetBytes());
            Console.Write(" Message Sent '" + Message1 + "'");

            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message2.GetBytes());
            Console.Write(" Message Sent '" + Message2 + "'");

            channel.BasicPublish(FanoutExchange.EXCHANGE_NAME, FanoutExchange.ROUTING_KEY, null, Message3.GetBytes());
            Console.Write(" Message Sent '" + Message3 + "'");
        }
    }
}

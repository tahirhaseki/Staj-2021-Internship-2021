using RabbitMQ.Client;
using RabbitMQandDockerProducer.Helpers;
using RabbitMQandDockerProducer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer.Exchanges.Header
{
    public class HeaderMessage : ISendMessage
    {
        public string Message1 => "First Header Message";
        public string Message2 => "Second Header Message";
        public string Message3 => "Third Header Message";

        public void SendMessage()
        {
            var connection = RabbitHelper.GetConnection;
            var channel = connection.CreateModel();
            var props = channel.CreateBasicProperties();
            var map1 = new Dictionary<string, object>();
            map1.Add("First", "A");
            map1.Add("Fourth", "D");
            props.Headers = map1;
            // First message sent by using ROUTING_KEY_1
            channel.BasicPublish(HeaderExchange.EXCHANGE_NAME, "", props, Message1.GetBytes());
            Console.Write(" Message Sent '" + Message1 + "'");

            props = channel.CreateBasicProperties();
            var map2 = new Dictionary<string, object>();
            map2.Add("Third", "C");
            props.Headers = map2;

            // Second message sent by using ROUTING_KEY_2
            channel.BasicPublish(HeaderExchange.EXCHANGE_NAME, "", props, Message2.GetBytes());
            Console.Write(" Message Sent '" + Message2 + "'");

            props = channel.CreateBasicProperties();
            var map3 = new Dictionary<string, object>();
            map3.Add("First", "A");
            map3.Add("Third", "C");
            props.Headers = map3;

            // Third message sent by using ROUTING_KEY_3
            channel.BasicPublish(HeaderExchange.EXCHANGE_NAME, "", props, Message3.GetBytes());
            Console.Write(" Message Sent '" + Message3 + "'");

        }
    }
}

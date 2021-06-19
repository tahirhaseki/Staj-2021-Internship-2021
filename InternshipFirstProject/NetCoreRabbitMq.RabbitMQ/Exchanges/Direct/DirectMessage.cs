using RabbitMQ.Client;
using InternshipFirstProject.RabbitMQ.Helpers;
using InternshipFirstProject.RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipFirstProject.RabbitMQ.Config;

namespace InternshipFirstProject.RabbitMQ.Exchanges.Direct
{
    public class DirectMessage : ISendMessage
    {
        public void SendMessage(RabbitMqMessageConfiguration messageConfig, IModel channel, byte[] body)
        {
            channel.BasicPublish(messageConfig.ExchangeName, messageConfig.RoutingKey, null, body);
        }
    }
}

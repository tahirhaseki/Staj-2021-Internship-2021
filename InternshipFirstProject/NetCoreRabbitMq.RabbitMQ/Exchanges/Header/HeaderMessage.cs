using RabbitMQ.Client;
using InternshipFirstProject.RabbitMQ.Helpers;
using InternshipFirstProject.RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipFirstProject.RabbitMQ.Config;

namespace InternshipFirstProject.RabbitMQ.Exchanges.Header
{
    public class HeaderMessage : ISendMessage
    {
        public void SendMessage(RabbitMqMessageConfiguration messageConfig, IModel channel, byte[] body)
        {
            var props = channel.CreateBasicProperties();
            props.Headers = messageConfig.HeaderMap;
            channel.BasicPublish(messageConfig.ExchangeName, "", props, body);

        }
    }
}

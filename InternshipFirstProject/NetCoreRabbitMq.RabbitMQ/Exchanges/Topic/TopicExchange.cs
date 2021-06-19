using RabbitMQ.Client;
using InternshipFirstProject.RabbitMQ.Helpers;
using InternshipFirstProject.RabbitMQ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipFirstProject.RabbitMQ.Config;

namespace InternshipFirstProject.RabbitMQ.Exchanges.Topic
{
    public class TopicExchange : IExchangeFactory
    {
        public void CreateExchangeAndQueue(RabbitMqExchangeConfiguration exchangeConfig, RabbitMqQueueConfiguration queueConfig, IModel channel)
        {
            channel.ExchangeDeclare(exchangeConfig.ExchangeName, exchangeConfig.ExchangeType, true);
            channel.QueueDeclare(queueConfig.QueueName, true, false, false, null);
            channel.QueueBind(queueConfig.QueueName, queueConfig.BindedExchangeName, queueConfig.RoutingInfo);

        }
    }
}

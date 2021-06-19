using InternshipFirstProject.RabbitMQ.Config;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipFirstProject.RabbitMQ.Interfaces
{
    public interface IExchangeFactory
    {
        void CreateExchangeAndQueue(RabbitMqExchangeConfiguration exchangeConfig,RabbitMqQueueConfiguration queueConfig,IModel channel);
    }
}

using InternshipFirstProject.RabbitMQ.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Interfaces
{
    public interface IRabbitHelper
    {
        void SendMessage<T>(T content, string TypeOfExchange
                        ,RabbitMqExchangeConfiguration exchangeConfig
                        ,RabbitMqQueueConfiguration queueConfig
                        ,RabbitMqMessageConfiguration messageConfig);

        public void DeclareQueueAndBindToExchange(RabbitMqQueueConfiguration queueConfig);
        public void DeclareQueue(RabbitMqQueueConfiguration queueConfig);
        public void DeclareExchange(RabbitMqExchangeConfiguration exchangeConfig);
    }
}

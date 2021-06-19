using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Config
{
    public class RabbitMqConfiguration
    {
        public RabbitMqConnectionConfiguration ConnectionConfig { get; set; }
        public RabbitMqExchangeConfiguration ExchangeConfig { get; set; }
        public RabbitMqQueueConfiguration QueueConfig { get; set; }
        public RabbitMqMessageConfiguration MessageConfig { get; set; }


        public RabbitMqConfiguration(RabbitMqConnectionConfiguration connectionConfig)
        {
            ConnectionConfig = connectionConfig;
        }

        public RabbitMqConfiguration(RabbitMqConnectionConfiguration connectionConfig, RabbitMqExchangeConfiguration exchangeConfig) : this(connectionConfig)
        {
            ExchangeConfig = exchangeConfig;
        }

        public RabbitMqConfiguration(RabbitMqConnectionConfiguration connectionConfig, RabbitMqExchangeConfiguration exchangeConfig, RabbitMqQueueConfiguration queueConfig) : this(connectionConfig, exchangeConfig)
        {
            QueueConfig = queueConfig;
        }

        public RabbitMqConfiguration(RabbitMqConnectionConfiguration connectionConfig, RabbitMqExchangeConfiguration exchangeConfig, RabbitMqQueueConfiguration queueConfig, RabbitMqMessageConfiguration messageConfig) : this(connectionConfig, exchangeConfig, queueConfig)
        {
            MessageConfig = messageConfig;
        }

        public RabbitMqConfiguration()
        {
        }
    }
}

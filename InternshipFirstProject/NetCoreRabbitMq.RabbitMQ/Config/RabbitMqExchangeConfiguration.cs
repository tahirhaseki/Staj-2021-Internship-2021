using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Config
{
    public class RabbitMqExchangeConfiguration
    {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }

        public RabbitMqExchangeConfiguration(string exchangeName, string exchangeType)
        {
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
        }

        public RabbitMqExchangeConfiguration()
        {
        }
    }
}

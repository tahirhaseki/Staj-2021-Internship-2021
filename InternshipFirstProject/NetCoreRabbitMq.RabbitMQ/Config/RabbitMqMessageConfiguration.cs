using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Config
{
    public class RabbitMqMessageConfiguration
    {
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
        public Dictionary<string,object> HeaderMap { get; set; }

        public RabbitMqMessageConfiguration(string exchangeName, string routingKey)
        {
            ExchangeName = exchangeName;
            RoutingKey = routingKey;
        }

        public RabbitMqMessageConfiguration(string exchangeName, Dictionary<string, object> headerMap)
        {
            ExchangeName = exchangeName;
            HeaderMap = headerMap;
        }
    }
}

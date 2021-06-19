using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Config
{
    public class RabbitMqQueueConfiguration
    {
        public string QueueName { get; set; }
        public string RoutingInfo { get; set; }
        public string BindedExchangeName { get; set; }
        public Dictionary<string,object> HeadersMap { get; set; }

        public RabbitMqQueueConfiguration(string queueName, string bindedExchangeName, string routingInfo)
        {
            QueueName = queueName;
            BindedExchangeName = bindedExchangeName;
            RoutingInfo = routingInfo;
        }

        public RabbitMqQueueConfiguration(string queueName, string bindedExchangeName, Dictionary<string, object> headersMap)
        {
            QueueName = queueName;
            BindedExchangeName = bindedExchangeName;
            HeadersMap = headersMap;
        }
    }
}

using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer.Helpers
{
    public class RabbitHelper
    {
        static Lazy<IConnection> _connection = new Lazy<IConnection>(CreateConnection);
        public static IConnection GetConnection => _connection.Value;
        static IConnection CreateConnection()
        {
            //var factory = new ConnectionFactory() { HostName = "localhost" , UserName="thaseki",Password="123456"};
            var factory = new ConnectionFactory() { HostName = "172.17.0.3"};
            var connection = factory.CreateConnection();
            return connection;
        }
    }
}

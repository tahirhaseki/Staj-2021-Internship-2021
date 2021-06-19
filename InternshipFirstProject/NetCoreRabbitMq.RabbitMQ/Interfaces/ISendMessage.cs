using InternshipFirstProject.RabbitMQ.Config;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipFirstProject.RabbitMQ.Interfaces
{
    public interface ISendMessage
    {
        void SendMessage(RabbitMqMessageConfiguration messageConfig, IModel channel,byte[] body);
    }
}

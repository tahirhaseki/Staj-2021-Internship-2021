using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Config
{
    public class RabbitMqConnectionConfiguration
    {
        public string Hostname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public RabbitMqConnectionConfiguration(string hostname, string userName, string password)
        {
            Hostname = hostname;
            UserName = userName;
            Password = password;
        }

        public RabbitMqConnectionConfiguration()
        {
        }
    }
}

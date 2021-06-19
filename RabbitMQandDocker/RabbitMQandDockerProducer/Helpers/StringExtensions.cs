using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer.Helpers
{
    public static class StringExtensions
    {
        public static byte[] GetBytes(this string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        public static string GetString(this byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }
    }
}

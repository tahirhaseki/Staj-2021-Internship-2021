using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQandDockerProducer.Exchanges.Direct;
using RabbitMQandDockerProducer.Exchanges.Fanout;
using RabbitMQandDockerProducer.Exchanges.Header;
using RabbitMQandDockerProducer.Exchanges.Topic;
using RabbitMQandDockerProducer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQandDockerProducer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*var exhangeFactory = CreateExchange(ExchangeType.Direct);
            exhangeFactory.CreateExchangeAndQueue();
            var producer = CreateSendMessage(ExchangeType.Direct);
            producer.SendMessage();*/

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static ISendMessage CreateSendMessage(string exchangeType)
        {

            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectMessage();
                case ExchangeType.Headers:
                    return new HeaderMessage();
                case ExchangeType.Topic:
                    return new TopicMessage();
                case ExchangeType.Fanout:
                    return new FanoutMessage();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }

        public static IExchangeFactory CreateExchange(string exchangeType)
        {

            switch (exchangeType)
            {
                case ExchangeType.Direct:
                    return new DirectExchange();
                case ExchangeType.Headers:
                    return new HeaderExchange();
                case ExchangeType.Topic:
                    return new TopicExchange();
                case ExchangeType.Fanout:
                    return new FanoutExchange();
                default:
                    throw new Exception("there is no properly exchange type");
            }
        }
    }
}

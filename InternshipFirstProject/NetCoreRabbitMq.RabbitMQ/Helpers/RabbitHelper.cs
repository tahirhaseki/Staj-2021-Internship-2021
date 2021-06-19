using InternshipFirstProject.RabbitMQ.Config;
using InternshipFirstProject.RabbitMQ.Exchanges.Direct;
using InternshipFirstProject.RabbitMQ.Exchanges.Fanout;
using InternshipFirstProject.RabbitMQ.Exchanges.Header;
using InternshipFirstProject.RabbitMQ.Exchanges.Topic;
using InternshipFirstProject.RabbitMQ.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternshipFirstProject.RabbitMQ.Helpers
{
    public class RabbitHelper: IRabbitHelper
    {
        private readonly RabbitMqConnectionConfiguration connectionConfiguration;
        private IConnection _connection;

        public RabbitHelper(IOptions<RabbitMqConnectionConfiguration> rabbitMqOptions)
        {
            connectionConfiguration = rabbitMqOptions.Value;
            CreateConnection();
        }

        public void SendMessage<T>(T content,string TypeOfExchange
                               ,RabbitMqExchangeConfiguration exchangeConfig
                               ,RabbitMqQueueConfiguration queueConfig
                               ,RabbitMqMessageConfiguration messageConfig)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    var json = JsonConvert.SerializeObject(content);
                    var body = Encoding.UTF8.GetBytes(json);
                    switch (TypeOfExchange)
                    {
                        case ExchangeType.Direct:
                            CreateExchange(ExchangeType.Direct).CreateExchangeAndQueue(exchangeConfig,queueConfig,channel);
                            new DirectMessage().SendMessage(messageConfig, channel,body);
                            break;
                        case ExchangeType.Fanout:
                            CreateExchange(ExchangeType.Fanout).CreateExchangeAndQueue(exchangeConfig, queueConfig, channel);
                            new FanoutMessage().SendMessage(messageConfig, channel, body);
                            break;
                        case ExchangeType.Headers:
                            CreateExchange(ExchangeType.Headers).CreateExchangeAndQueue(exchangeConfig, queueConfig, channel);
                            new HeaderMessage().SendMessage(messageConfig, channel, body);
                            break;
                        case ExchangeType.Topic:
                            CreateExchange(ExchangeType.Topic).CreateExchangeAndQueue(exchangeConfig, queueConfig, channel);
                            new TopicMessage().SendMessage(messageConfig, channel, body);
                            break;
                        default:
                            break;
                    }
                    _connection.Close();
                }
            }
        }

        public void DeclareQueueAndBindToExchange(RabbitMqQueueConfiguration queueConfig)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queueConfig.QueueName, true, false, false, null);
                    channel.QueueBind(queueConfig.QueueName, queueConfig.BindedExchangeName, queueConfig.RoutingInfo);
                    _connection.Close();
                }
            }

        }

        public void DeclareQueue(RabbitMqQueueConfiguration queueConfig)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                { 
                    channel.QueueDeclare(queueConfig.QueueName, true, false, false, null);
                    _connection.Close();
                }
            }
        }
        public void DeclareExchange(RabbitMqExchangeConfiguration exchangeConfig)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchangeConfig.ExchangeName, exchangeConfig.ExchangeType, true);
                    _connection.Close();
                }
            }
        }

        private IExchangeFactory CreateExchange(string exchangeType)
        {

            return exchangeType switch
            {
                ExchangeType.Direct => new DirectExchange(),
                ExchangeType.Headers => new HeaderExchange(),
                ExchangeType.Topic => new TopicExchange(),
                ExchangeType.Fanout => new FanoutExchange(),
                _ => throw new Exception("there is no properly exchange type"),
            };
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = connectionConfiguration.Hostname,
                    UserName = connectionConfiguration.UserName,
                    Password = connectionConfiguration.Password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}

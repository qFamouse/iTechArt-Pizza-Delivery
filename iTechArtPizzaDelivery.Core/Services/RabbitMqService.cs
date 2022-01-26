using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace iTechArtPizzaDelivery.Core.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;

        public RabbitMqService(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _rabbitMqConfiguration = rabbitMqConfiguration.Value ?? throw new ArgumentNullException(nameof(rabbitMqConfiguration));
        }

        public IConnection CreateConnection()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = _rabbitMqConfiguration.Hostname,
                UserName = _rabbitMqConfiguration.Username,
                Password = _rabbitMqConfiguration.Password
            };

            return factory.CreateConnection();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Views;
using RabbitMQ.Client;

namespace iTechArtPizzaDelivery.Core.Services
{
    public class MailerService : IMailerService, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MailerService(IRabbitMqService rabbitMqService)
        {
            _connection = rabbitMqService.CreateConnection() ?? throw new NullReferenceException(nameof(_connection));
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: "Mailer",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void SendMail(MailView mail)
        {
            var body = Encoding.UTF8.GetBytes(mail.ToString());

            _channel.BasicPublish(
                exchange: "",
                routingKey: "Mailer",
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
            }

            if (_connection.IsOpen)
            {
                _connection.Close();
            }
        }
    }
}
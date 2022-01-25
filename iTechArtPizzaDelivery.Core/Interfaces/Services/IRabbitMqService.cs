using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IRabbitMqService
    {
        public IConnection CreateConnection();
    }
}
using iTechArtPizzaDelivery.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services
{
    public interface IMailerService
    {
        void SendMail(MailView mail);
    }
}
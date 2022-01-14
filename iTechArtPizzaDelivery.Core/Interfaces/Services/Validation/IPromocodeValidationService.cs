using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface IPromocodeValidationService
    {
        void PromocodeIsValid(Promocode code);
        Task PromocodeIsExists(string code);
    }
}

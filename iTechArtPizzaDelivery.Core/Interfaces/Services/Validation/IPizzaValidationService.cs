using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface IPizzaValidationService
    {
        Task PizzaExistsAsync(int id);
        void ValidateImage(IFormFile imageFile);
        Task ImageExistsAsync(int? id);
    }
}

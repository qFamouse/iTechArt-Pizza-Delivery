using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Validation
{
    public interface IPizzasValidationService
    {
        Task PizzaExistsAsync(int id);
        void ImageValidation(IFormFile imageFile);
    }
}

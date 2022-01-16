using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.Core.Services.Validation
{
    public class PizzaValidationService : IPizzasValidationService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ResourceConfiguration _resourceConfiguration;

        public PizzaValidationService(IPizzaRepository pizzaRepository, IOptions<ResourceConfiguration> resourceConfiguration)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            _resourceConfiguration =
                resourceConfiguration.Value ?? throw new ArgumentNullException(nameof(resourceConfiguration));
        }

        public void ImageValidation(IFormFile imageFile)
        {
            if (imageFile is null)
            {
                throw new HttpStatusCodeException(400, "Image is empty");
            }

            var ext = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !_resourceConfiguration.AllowedImageContentTypes.Contains(ext))
            {
                throw new HttpStatusCodeException(400, "Invalid image extension");
            }

            if (imageFile.Length > _resourceConfiguration.ImageSizeLimit)
            {
                throw new HttpStatusCodeException(400, "Image is too large");
            }
        }

        public async Task PizzaExistsAsync(int id)
        {
            if (!await _pizzaRepository.IsExists(id))
            {
                throw new HttpStatusCodeException(404, "Pizza not found");
            }
        }
    }
}

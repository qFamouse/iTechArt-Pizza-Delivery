using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzasValidationService _pizzasValidationService;
        private readonly IMapper _mapper;
        private readonly ResourceConfiguration _resourceConfig;
        private readonly IPizzaImageRepository _pizzaImageRepository;

        public PizzaService(IPizzaRepository pizzaRepository, IPizzasValidationService pizzasValidationService,
            IMapper mapper, IOptions<ResourceConfiguration> resourceConfig, IPizzaImageRepository pizzaImageRepository)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            _pizzasValidationService = pizzasValidationService ??
                                       throw new ArgumentNullException(nameof(pizzasValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _resourceConfig = resourceConfig.Value ?? throw new ArgumentNullException(nameof(resourceConfig));
            _pizzaImageRepository =
                pizzaImageRepository ?? throw new ArgumentNullException(nameof(pizzaImageRepository));
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaRepository.GetAllAsync();
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await _pizzaRepository.GetByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Pizza not found");
        }

        public async Task<Pizza> AddAsync(PizzaInsertRequest request)
        {
            var pizza = _mapper.Map<Pizza>(request);
            await _pizzaRepository.InsertAsync(pizza);
            await _pizzaRepository.Save();
            return pizza;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _pizzasValidationService.PizzaExistsAsync(id);
            await _pizzaRepository.DeleteByIdAsync(id);
            await _pizzaRepository.Save();
        }

        public async Task<Pizza> UpdateByIdAsync(int id, PizzaUpdateRequest request)
        {
            await _pizzasValidationService.PizzaExistsAsync(id);
            var pizza = _mapper.Map<Pizza>(request);
            pizza.Id = id;

            _pizzaRepository.Update(pizza);
            await _pizzaRepository.Save();

            return pizza;
        }

        public async Task<PizzaImage> UploadImageAsync(IFormFile uploadedFile)
        {
            _pizzasValidationService.ImageValidation(uploadedFile);

            // Get Path to image folder
            var uploadedFileExtension = Path.GetExtension(uploadedFile.FileName).ToLowerInvariant();

            var resourceDirectory = Directory.CreateDirectory(_resourceConfig.ApplicationDataPath);
            var imageDirectory = resourceDirectory.CreateSubdirectory(_resourceConfig.PizzaImageName);

            var imageName = $"pizza_{DateTime.Now.Ticks}{uploadedFileExtension}";

            var pathToImage = $"{imageDirectory}\\{imageName}";

            // Save image
            await using var fileStream = new FileStream(pathToImage, FileMode.Create);
            await uploadedFile.CopyToAsync(fileStream);

            var pizzaImage = new PizzaImage()
            {
                Filename = imageName
            };

            await _pizzaImageRepository.InsertAsync(pizzaImage);
            await _pizzaImageRepository.Save();

            return pizzaImage;
        }

        public async Task<FileStream> DownloadImageAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

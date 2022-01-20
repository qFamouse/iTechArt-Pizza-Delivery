using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Exceptions;
using iTechArtPizzaDelivery.Core.Interfaces;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using iTechArtPizzaDelivery.Core.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaValidationService _pizzasValidationService;
        private readonly IMapper _mapper;
        private readonly ResourceConfiguration _resourceConfig;
        private readonly IPizzaImageRepository _pizzaImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PizzaService(IPizzaRepository pizzaRepository, IPizzaValidationService pizzasValidationService,
            IMapper mapper, IOptions<ResourceConfiguration> resourceConfig, IPizzaImageRepository pizzaImageRepository,
            IUnitOfWork unitOfWork)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
            _pizzasValidationService = pizzasValidationService ??
                                       throw new ArgumentNullException(nameof(pizzasValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _resourceConfig = resourceConfig.Value ?? throw new ArgumentNullException(nameof(resourceConfig));
            _pizzaImageRepository =
                pizzaImageRepository ?? throw new ArgumentNullException(nameof(pizzaImageRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaRepository.GetAllAsync();
        }

        public Task<List<Pizza>> GetAllByPageAsync(int pageNumber)
        {
            return _pizzaRepository.GetAllByPageAsync(pageNumber);
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            return await _pizzaRepository.GetByIdAsync(id) ??
                   throw new HttpStatusCodeException(404, "Pizza not found");
        }

        public async Task<Pizza> AddAsync(PizzaInsertRequest request)
        {
            await _pizzasValidationService.ImageExistsAsync(request.PizzaImageId);

            var pizza = _mapper.Map<Pizza>(request);
            await _pizzaRepository.InsertAsync(pizza);
            await _pizzaRepository.Save();
            return pizza;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _pizzasValidationService.PizzaExistsAsync(id);

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var pizzaImageId = (await _pizzaRepository.GetByIdAsync(id)).PizzaImageId;

                    await _pizzaRepository.DeleteByIdAsync(id);
                    await _pizzaRepository.Save();

                    if (pizzaImageId != null)
                    {
                        await DeleteImage(pizzaImageId.Value);
                    }

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new HttpStatusCodeException(500, "Pizza can not be deleted");
                }

            }
        }

        public async Task<Pizza> UpdateByIdAsync(int id, PizzaUpdateRequest request)
        {
            await _pizzasValidationService.ImageExistsAsync(request.PizzaImageId);
            await _pizzasValidationService.PizzaExistsAsync(id);

            var pizza = _mapper.Map<Pizza>(request);
            pizza.Id = id;
            _pizzaRepository.Update(pizza);
            await _pizzaRepository.Save();
            return pizza;
        }

        public async Task<PizzaImage> UploadImageAsync(IFormFile uploadedFile)
        {
            _pizzasValidationService.ValidateImage(uploadedFile);

            // Get Path to image folder
            var uploadedFileExtension = Path.GetExtension(uploadedFile.FileName).ToLowerInvariant();

            var resourceDirectory = Directory.CreateDirectory(_resourceConfig.ResourcePath);
            var imageDirectory = resourceDirectory.CreateSubdirectory(_resourceConfig.PizzaImageName);

            var imageName = $"pizza_{DateTime.Now.Ticks}{uploadedFileExtension}";

            var pathToImage = $"{imageDirectory}\\{imageName}";

            // Save image
            var pizzaImage = new PizzaImage()
            {
                Filename = imageName
            };

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _pizzaImageRepository.InsertAsync(pizzaImage);
                    await _pizzaImageRepository.Save();
                    
                    await using var fileStream = new FileStream(pathToImage, FileMode.Create);
                    await uploadedFile.CopyToAsync(fileStream);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new HttpStatusCodeException(500, "Can't upload image");
                }
            }

            return pizzaImage;
        }

        public async Task<ImageView> DownloadImageAsync(int id)
        {
            var pizzaImage = await _pizzaImageRepository.GetByIdAsync(id) ??
                             throw  new HttpStatusCodeException(404, "Image not found");

            // Get Path to image folder
            var resourceDirectory = Directory.CreateDirectory(_resourceConfig.ResourcePath);
            var imageDirectory = resourceDirectory.CreateSubdirectory(_resourceConfig.PizzaImageName);

            var imageName = pizzaImage.Filename;

            var pathToImage = $"{imageDirectory}\\{imageName}";

            // Get Content type
            new FileExtensionContentTypeProvider().TryGetContentType(imageName, out string contentType);

            return new ImageView()
            {
                Image = File.OpenRead(pathToImage),
                ContentType = contentType
            };
        }

        public async Task DeleteImage(int id)
        {
            await _pizzasValidationService.ImageExistsAsync(id);

            // Get Path to image folder
            var pizzaImage = await _pizzaImageRepository.GetByIdAsync(id);
            var resourceDirectory = Directory.CreateDirectory(_resourceConfig.ResourcePath);
            var imageDirectory = resourceDirectory.CreateSubdirectory(_resourceConfig.PizzaImageName);

            var imageName = pizzaImage.Filename;

            var pathToImage = $"{imageDirectory}\\{imageName}";

            // Delete image
            if (!File.Exists(pathToImage))
            {
                throw new HttpStatusCodeException(404, "File was not found on the server");
            }

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _pizzaImageRepository.DeleteByIdAsync(id);
                    await _pizzaImageRepository.Save();

                    File.Delete(pathToImage);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new HttpStatusCodeException(500, "Can't delete image");
                }
            }
        }
    }
}

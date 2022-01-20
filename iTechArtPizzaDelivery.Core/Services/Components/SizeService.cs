using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Components;
using iTechArtPizzaDelivery.Core.Interfaces.Services.Validation;
using iTechArtPizzaDelivery.Core.Requests.Size;

namespace iTechArtPizzaDelivery.Core.Services.Components
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly ISizeValidationService _sizesValidationService;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, ISizeValidationService sizesValidationService,
            IMapper mapper)
        {
            _sizeRepository = sizeRepository ?? throw new ArgumentNullException(nameof(sizeRepository));
            _sizesValidationService =
                sizesValidationService ?? throw new ArgumentNullException(nameof(sizesValidationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Size>> GetAllAsync()
        {
            return await _sizeRepository.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _sizeRepository.GetByIdAsync(id);
        }

        public async Task<Size> InsertAsync(SizeInsertRequest request)
        {
            var size = _mapper.Map<Size>(request);
            await _sizeRepository.InsertAsync(size);
            await _sizeRepository.Save();
            return size;
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _sizesValidationService.SizeExistsAsync(id);
            await _sizeRepository.DeleteByIdAsync(id);
            await _sizeRepository.Save();
        }

        public async Task<Size> UpdateByIdAsync(int id, SizeUpdateRequest request)
        {
            await _sizesValidationService.SizeExistsAsync(id);
            var size = _mapper.Map<Size>(request);
            size.Id = id;

            _sizeRepository.Update(size);
            await _sizeRepository.Save();

            return size;
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Requests.Pizza;
using iTechArtPizzaDelivery.Core.Views;
using Microsoft.AspNetCore.Http;

namespace iTechArtPizzaDelivery.Core.Interfaces.Services.Components
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAllAsync();
        Task<List<Pizza>> GetAllByPageAsync(int pageNumber);
        Task<Pizza> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task<Pizza> AddAsync(PizzaInsertRequest request);
        Task<Pizza> UpdateByIdAsync(int id, PizzaUpdateRequest request);
        Task<PizzaImage> UploadImageAsync(IFormFile file);
        Task<ImageView> DownloadImageAsync(int id);
        Task DeleteImage(int id);
    }
}
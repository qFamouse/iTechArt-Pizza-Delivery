using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace iTechArtPizzaDelivery.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task Save();
    }
}

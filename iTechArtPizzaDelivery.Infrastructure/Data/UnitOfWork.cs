using System.Data;
using iTechArtPizzaDelivery.Core.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace iTechArtPizzaDelivery.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaDeliveryContext _pizzaDeliveryContext;

        public UnitOfWork(PizzaDeliveryContext pizzaDeliveryContext)
        {
            _pizzaDeliveryContext = pizzaDeliveryContext;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _pizzaDeliveryContext.Database.BeginTransactionAsync();
        }

        public async Task Save()
        {
            await _pizzaDeliveryContext.SaveChangesAsync();
        }
    }
}
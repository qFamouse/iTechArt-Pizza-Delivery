using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.Payment;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PaymentEFRepository : BaseEFRepository, IPaymentRepository
    {
        public PaymentEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Payment> AddAsync(PaymentAddRequest request)
        {
            var payment = _mapper.Map<Payment>(request);
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var payment = await _dbContext.Payments
                .SingleAsync(p => p.Id == id);
            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _dbContext.Payments.ToListAsync();
        }
    }
}

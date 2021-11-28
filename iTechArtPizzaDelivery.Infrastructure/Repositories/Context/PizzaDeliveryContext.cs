using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.Context
{
    public class PizzaDeliveryContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<PizzaSize> PizzasSizes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaDelivery;Trusted_Connection=True;");
            // Trusted_Connection = true -- Authentication based on Windows accounts 
        }
    }
}

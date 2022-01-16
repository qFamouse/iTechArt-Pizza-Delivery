using iTechArtPizzaDelivery.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data
{
    public class PizzaDeliveryContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<PizzaImage> PizzaImages { get; set; }
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

        /// <summary>
        /// Install connection string by constructor in startup.cs
        /// </summary>
        /// <param name="options"></param>
        public PizzaDeliveryContext(DbContextOptions<PizzaDeliveryContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaDelivery;Trusted_Connection=True;");
        //    // Trusted_Connection = true -- Authentication based on Windows accounts 
        //}
    }
}

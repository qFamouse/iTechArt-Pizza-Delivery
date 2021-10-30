﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.Context
{
    public class PizzaDeliveryContext : DbContext
    {
        public DbSet<PizzaSize> PizzasSizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaDelivery;Trusted_Connection=True;");
            // Trusted_Connection = true -- Authentication based on Windows accounts 
        }
    }
}
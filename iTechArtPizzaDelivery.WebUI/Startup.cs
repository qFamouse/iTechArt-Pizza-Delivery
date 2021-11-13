using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Profiles;

namespace iTechArtPizzaDelivery.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(PizzaSizeProfile))); // Get Assembly by some class from this assembly
            // Other method using hard brute force
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName.StartsWith("iTechArtPizzaDelivery.Infrastructure")));
            services.AddAutoMapper(typeof(Startup));
            // Domain
            services.AddScoped<IPizzasSizesRepository, PizzaSizeEFRepository>();
            services.AddScoped<PizzasSizesService>();

            services.AddScoped<IPizzaRepository, PizzaEFRepository>();
            services.AddScoped<PizzasService>();

            services.AddScoped<ISizeRepository, SizeEFRepository>();
            services.AddScoped<SizesService>();

            services.AddScoped<IIngredientRepository, IngredientEFRepository>();
            services.AddScoped<IngredientsService>();

            services.AddScoped<IPizzaIngredientRepository, PizzaIngredientEFRepository>();
            services.AddScoped<PizzasIngredientsService>();

            services.AddScoped<IOrderRepository, OrderEFRepository>();
            services.AddScoped<OrderService>();

            services.AddScoped<IPromocodeRepository, PromocodeEFRepository>();
            services.AddScoped<PromocodesService>();
            // Infrastructure
            services.AddDbContext<PizzaDeliveryContext>();
            // WebUI
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArtPizzaDelivery.WebUI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iTechArtPizzaDelivery.WebUI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

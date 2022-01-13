using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using iTechArtPizzaDelivery.Core.Configurations;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Interfaces.Services;
using iTechArtPizzaDelivery.Core.Mapping;
using iTechArtPizzaDelivery.Core.Services;
using iTechArtPizzaDelivery.Infrastructure.Data;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Account;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Components;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Construction;
using iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping;
using iTechArtPizzaDelivery.WebUI.Middleware;
using iTechArtPizzaDelivery.WebUI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            services.Configure<IdentityConfiguration>(Configuration.GetSection("Identity"));
            // AutoMapper
            // services.AddAutoMapper(Assembly.GetAssembly(typeof(PizzaSizeProfile))); // Get Assembly by some class from this assembly
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile))); // Get Assembly by some class from this assembly
            // Other method using hard brute force
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName.StartsWith("iTechArtPizzaDelivery.Infrastructure")));
            services.AddAutoMapper(typeof(Startup));
            // Domain
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IPizzasService, PizzasService>();

            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizesService, SizesService>();

            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientsService, IngredientsService>();

            

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IPromocodeRepository, PromocodeRepository>();
            services.AddScoped<IPromocodeService, PromocodesService>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemService, OrdersItemsService>();

            services.AddScoped<IPizzaSizeRepository, PizzaSizeRepository>();
            services.AddScoped<IPizzaIngredientRepository, PizzaIngredientRepository>();
            services.AddScoped<IPizzaConstructionService, PizzaConstructionService>();

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDeliveriesService, DeliveryService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentsService, PaymentService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IIdentityService, IdentityService>();
            // Infrastructure
            services.AddDbContext<PizzaDeliveryContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // WebUI

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["Identity:SecurityKey"]))
                        };
                    }
                );

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<PizzaDeliveryContext>()
                .AddDefaultTokenProviders();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iTechArtPizzaDelivery.WebUI", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = @"JWT Authorization header using the Bearer scheme. 
                                      Enter 'Bearer' [space] and then your token in the text input below.
                                      Example: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new string[] { }
                    }
                });
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

            //app.ConfigureCustomExceptionMiddleware();
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

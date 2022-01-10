using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using iTechArtPizzaDelivery.Domain.Configurations;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;
using iTechArtPizzaDelivery.Domain.Mapping;
using iTechArtPizzaDelivery.Domain.Services;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Profiles;
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
            services.AddAutoMapper(Assembly.GetAssembly(typeof(PizzaSizeProfile))); // Get Assembly by some class from this assembly
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile))); // Get Assembly by some class from this assembly
            // Other method using hard brute force
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.FullName.StartsWith("iTechArtPizzaDelivery.Infrastructure")));
            services.AddAutoMapper(typeof(Startup));
            // Domain
            services.AddScoped<IPizzaRepository, PizzaEFRepository>();
            services.AddScoped<PizzasService>();

            services.AddScoped<ISizeRepository, SizeEFRepository>();
            services.AddScoped<SizesService>();

            services.AddScoped<IIngredientRepository, IngredientEFRepository>();
            services.AddScoped<IngredientsService>();

            

            services.AddScoped<IOrderRepository, OrderEFRepository>();
            services.AddScoped<OrderService>();

            services.AddScoped<IPromocodeRepository, PromocodeEFRepository>();
            services.AddScoped<PromocodesService>();

            services.AddScoped<IOrderItemRepository, OrderItemEFRepository>();
            services.AddScoped<OrdersItemsService>();

            services.AddScoped<IPizzaSizeRepository, PizzaSizeEFRepository>();
            services.AddScoped<IPizzaIngredientRepository, PizzaIngredientEFRepository>();
            services.AddScoped<PizzaConstructionService>();

            services.AddScoped<IDeliveryRepository, DeliveryEFRepository>();
            services.AddScoped<DeliveryService>();

            services.AddScoped<IPaymentRepository, PaymentEFRepository>();
            services.AddScoped<PaymentService>();

            services.AddScoped<IUserRepository, UserEFRepository>();
            services.AddScoped<UsersService>();

            services.AddScoped<IdentityService>();

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

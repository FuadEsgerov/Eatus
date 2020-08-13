using API.Email;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Data;
using Repository.Data.Identity;
using Repository.Repositories;
using Repository.Repositories.ShoppingRepositories;
using Repository.Services;
using StackExchange.Redis;


namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
          .AddGoogle(opts =>
          {
              opts.ClientId = "861426078421-9e2gfcdgmlhr06dmjut4o34h9g9b8pev.apps.googleusercontent.com";
              opts.ClientSecret = "YPWE9WZ4eqME_zWObIsPCWdI";
              opts.SignInScheme = IdentityConstants.ExternalScheme;
          });

            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();
            
            services.AddDbContext<AppDbContext>(options =>
       options.UseSqlServer(_config.GetConnectionString("Default"),
       x => x.MigrationsAssembly("Repository")));
            services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(_config.GetConnectionString("DefaultIdentity")));
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            // Email Sending Service
            services.AddSendGridEmailSender();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"),
                    true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
            services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseRouting();
         

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

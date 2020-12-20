using System;
using Domain;
using Domain.Contracts.Handlers;
using Domain.Contracts.Repositories;
using Domain.Handlers;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            // services.AddDbContext<AppDbContext>(options =>
            //    options.UseInMemoryDatabase(Settings.ConnectionString()));

            //Use SQLite            
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlite(Settings.ConnectionString()));
            
        }  

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();               
        }
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.AddScoped<IProductHandler, ProductHandler>();
        }                                   
        
        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Product Demo API",
                    Description = "A simple example ASP.NET Core Web API",                
                    Contact = new OpenApiContact
                    {
                        Name = "Vitor Moschetta",
                        Email = string.Empty,
                        Url = new Uri("https://vitormoschetta.github.io/")
                    }                   
                });
            });
        }   
    }
}
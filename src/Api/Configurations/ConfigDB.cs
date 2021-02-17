using Domain;
using Infra.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureDbContext(
            this IServiceCollection Services, 
            IWebHostEnvironment Enviroment, 
            IConfiguration Configuration)
        {            
            var connectionString = string.Empty;

            if (Enviroment.EnvironmentName == "Development")
                connectionString = Configuration.GetConnectionString("ConnectionDev");
            else
                connectionString = Configuration.GetConnectionString("ConnectionProd");

            Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));


            // Iniciliza classe de configuração da camada Domain
            var appSettings = new AppSettings(connectionString);
        }
        
    }
}
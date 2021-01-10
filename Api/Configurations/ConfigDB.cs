using Domain;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseInMemoryDatabase(Settings.ConnectionString()));

            //Use SQLite            
            // services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlite(Settings.ConnectionString()));
            
        }  
        
    }
}
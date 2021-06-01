using Domain.Commands.Handlers;
using Domain.Contracts.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.AddScoped<IProductHandler, ProductCommandHandler>();
        }    
    }
}
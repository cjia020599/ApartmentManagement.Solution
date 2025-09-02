using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Application.CommandHandler;
using PropertyManagement.Application.Commands;

namespace PropertyManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyApplication(this IServiceCollection services)
        {
            services.AddScoped<IPropertyCommands, PropertyCommands>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using OwnerManagement.Application.CommandHandler;
using OwnerManagement.Application.Commands;

namespace OwnerManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnerManagementApplication(this IServiceCollection services)
        {
            services.AddScoped<IOwnerCommands, OwnerCommands>();
            services.AddScoped<IIndividualUnitCommands, IndividualUnitCommands>();
            return services;
        }
    }
}

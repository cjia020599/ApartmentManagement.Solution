using Microsoft.Extensions.DependencyInjection;
using OwnerManagement.Application.CommandHandler;
using OwnerManagement.Application.Commands;
using MediatR;

namespace OwnerManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnerManagementApplication(this IServiceCollection services)
        {
            services.AddScoped<IOwnerCommands, OwnerCommands>();
            services.AddScoped<IIndividualUnitCommands, IndividualUnitCommands>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}

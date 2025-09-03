using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Application.CommandHandler;
using PropertyManagement.Application.Commands;
using MediatR;

namespace PropertyManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyApplication(this IServiceCollection services)
        {
            services.AddScoped<IPropertyCommands, PropertyCommands>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}

using FinancialManagement.Application.CommandHandler;
using FinancialManagement.Application.Commands;
using FinancialManagement.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFinancialManagementApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DependencyInjection));
            services.AddScoped<IRentPaymentCommands, RentPaymentCommands>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RentPaymentCommands).Assembly));
            return services;
        }
    }
}

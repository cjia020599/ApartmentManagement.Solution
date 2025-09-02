using FinancialManagement.Application.CommandHandler;
using FinancialManagement.Application.Commands;
using FinancialManagement.Application.Queries;
using FinancialManagement.Domain.Repositories;
using FinancialManagement.Infrastructure.Data;
using FinancialManagement.Infrastructure.Data.Repositories;
using FinancialManagement.Infrastructure.QueryHandlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFinancialManagementInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinancialDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsHistoryTable("_EFMigrationsHistory", "Financial"));
            });
            services.AddScoped<IRentPaymentQueries, RentPaymentQueries>();
            services.AddScoped<IRentPaymentRepository, RentPaymentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

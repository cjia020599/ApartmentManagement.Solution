using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenantAndLeaseManagement.Application.Queries;
using TenantAndLeaseManagement.Domain.Repositories;
using TenantAndLeaseManagement.Infrastructure.Data;
using TenantAndLeaseManagement.Infrastructure.Data.Repositories;
using TenantAndLeaseManagement.Infrastructure.QueryHandlers;

namespace TenantAndLeaseManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenantAndLeaseManagementInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TenantAndLeaseDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "TenantAndLease"));
            });
            services.AddScoped<ITenantQueries, TenantQueries>();
            services.AddScoped<ILeaseAgreementQueries, LeaseAgreementQueries>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ILeaseAgreementRepository, LeaseAgreementRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }   
    }
}

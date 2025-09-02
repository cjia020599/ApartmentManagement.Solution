using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyManagement.Application.Queries;
using PropertyManagement.Domain.Repositories;
using PropertyManagement.Infrastructure.Data;
using PropertyManagement.Infrastructure.Data.Repositories;
using PropertyManagement.Infrastructure.QueryHandlers;

namespace PropertyManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PropertyDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Property"));
            });
            services.AddScoped<IPropertyQueries, PropertyQueries>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork >();

            return services;
        }
    }
}

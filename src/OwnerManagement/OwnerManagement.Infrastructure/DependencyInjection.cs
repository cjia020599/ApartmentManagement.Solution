using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OwnerManagement.Application.Queries;
using OwnerManagement.Domain.Repositories;
using OwnerManagement.Infrastructure.Data;
using OwnerManagement.Infrastructure.Data.Respositories;
using OwnerManagement.Infrastructure.QueryHandlers;

namespace OwnerManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnerManagementInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OwnerDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Owner"));
            });
            services.AddScoped<IUnitOFWork, UnitOfWork>();
            services.AddScoped<IOwnerRespository, OwnerRepository>();
            services.AddScoped<IIndividualUnitRepository, IndividualUnitRepository>();
            services.AddScoped<IOwnerQueries, OwnerQueries>();
            services.AddScoped<IIndividualUnitQueries, IndividualUnitQueries>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantAndLeaseManagement.Application.CommandHandler;
using TenantAndLeaseManagement.Application.Commands;

namespace TenantAndLeaseManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenantAndLeaseManagementApplication(this IServiceCollection services)
        {
            services.AddScoped<ITenantCommands, TenantCommands>();
            services.AddScoped<ILeaseCommands, LeaseCommands>();
            return services;
        }
    }
}

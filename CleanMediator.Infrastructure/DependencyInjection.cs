using CleanMediator.Domain.Repository;
using CleanMediator.Infrastructure.Data;
using CleanMediator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration iconfiguration)
        {
            services.AddDbContext<TenantDbContext>(options =>
                options.UseNpgsql(iconfiguration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAccountRepository, AccountRepository>();

            return services;
        }   
    }
}

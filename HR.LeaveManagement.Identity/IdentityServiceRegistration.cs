using HR.LeaveManagement.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementIdentityDbContext>(options=>
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString")));
            return services;
        }
    }
}

using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Identity;
using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementIdentityDbContext>(options=>
            options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthServise>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}

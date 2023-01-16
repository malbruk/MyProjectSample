using Microsoft.Extensions.DependencyInjection;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Repositories;
using MyProject.Services.CachedServices;

namespace MyProject.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IRoleService, RoleService>();
            services.Decorate<IRoleService, CachedRoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IClaimService, ClaimService>();
            
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMemoryCache();

            return services;
        }
    }
}

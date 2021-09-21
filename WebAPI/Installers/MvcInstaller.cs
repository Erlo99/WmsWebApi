using Application;
using Application.Middleware;
using Application.Mappings;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("BasicAuthentication", null);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagmentUsers",
                     policy => policy.RequireRole("SuperAdmin","Admin","Manager"));
                options.AddPolicy("AdminUsers",
                     policy => policy.RequireRole("SuperAdmin","Admin"));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
        }
    }
}

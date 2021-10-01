using Application;
using Application.Middleware;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

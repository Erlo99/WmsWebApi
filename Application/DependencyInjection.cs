using Application.interfaces;
using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStoresService, StoresService>();
            services.AddScoped<IUserStoresSevice, UserStoresService>();


            services.AddScoped<ICargosService, CargosService>();
            services.AddScoped<ILocationCargosService, LocationCargosService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationSizesService, LocationSizesService>();
            services.AddScoped<IUserOperationsService, UserOperationsService>();

            return services;
        }
    }
}

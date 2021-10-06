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
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IUserStoreService, UserStoreService>();


            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<ILocationCargoService, LocationCargoService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationSizeService, LocationSizeService>();
            services.AddScoped<ILocationCargoOperationSevice, LocationCargoOperationSevice>();

            return services;
        }
    }
}

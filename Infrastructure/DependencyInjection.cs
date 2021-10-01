using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IUserStoreRepository, UserStoreRepository>();

            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ILocationCargoRepository, LocationCargoRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationSizeRepository, LocationSizeRepository>();
            services.AddScoped<IUserOperationRepository, UserOperationRepository>();
            return services;
        }
    }
}

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

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IStoresRepository, StoresRepository>();
            services.AddScoped<IUserStoresRepository, UserStoresRepository>();

            services.AddScoped<ICargosRepository, CargosRepository>();
            services.AddScoped<ILocationCargosRepository, LocationCargosRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationSizesRepository, LocationSizesRepository>();
            services.AddScoped<IUserOperationsRepository, UserOperationsRepository>();
            return services;
        }
    }
}

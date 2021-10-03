using Domain.Common;
using Domain.Entities;
using Domain.Entities.Users;
using Domain.Entities.Views;
using Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class WmsContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        public WmsContext( DbContextOptions options, IHttpContextAccessor httpContextAccessor, ILogger<WmsContext> logger) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<UserStore> UserStores { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<LocationCargoOperation> LocationCargoOperation { get; set; }
        public DbSet<UserOperation> UserOperations { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<LocationSize> LocationSizes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCargo> LocationCargos { get; set; }

        #region Views
        public DbSet<UserStoreView> userStoresViews { get; set; }
        public DbSet<UserOperationView> UserOperationsView { get; set; }


        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // get ApplyConfiguration method with reflection
            var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);
            // replace GetExecutingAssembly with assembly where your configurations are if necessary
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters))
            {
                // use type.Namespace to filter by namespace if necessary
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            foreach (var entityEntry in entries)
            {
                ((AuditableEntity)entityEntry.Entity).LastModifiedAt = DateTime.UtcNow;
                ((AuditableEntity)entityEntry.Entity).LastModifiedBy = userName;

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    ((AuditableEntity)entityEntry.Entity).CreatedBy = userName;
                }
                if (entityEntry.State == EntityState.Deleted)
                {
                    _logger.LogInformation($"User {userName} deleted: " + entityEntry.OriginalValues.ToObject().ToString());
                }
            }

            return base.SaveChanges();
        }

    }
}

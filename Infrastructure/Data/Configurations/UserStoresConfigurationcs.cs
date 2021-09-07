using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    class UserStoresConfigurationcs : IEntityTypeConfiguration<UserStores>
    {
        public void Configure(EntityTypeBuilder<UserStores> builder)
        {
            builder.HasKey(u => new { 
                u.UserId,
                u.StoreId
            });
        }
    }
}

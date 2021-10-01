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
    class UserStoreConfiguration : IEntityTypeConfiguration<UserStore>
    {
        public void Configure(EntityTypeBuilder<UserStore> builder)
        {
            builder.HasKey(u => new { 
                u.UserId,
                u.StoreId
            });
        }
    }
}

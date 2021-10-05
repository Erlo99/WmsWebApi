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
    class LocationSizeConfiguration : IEntityTypeConfiguration<LocationSize>
    {
        public void Configure(EntityTypeBuilder<LocationSize> builder)
        {
            builder.HasIndex(u => u.SizeName).IsUnique();
        }
    }
}

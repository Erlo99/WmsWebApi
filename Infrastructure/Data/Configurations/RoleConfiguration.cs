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
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(Enum.GetValues(typeof(RoleEnum))
                    .Cast<RoleEnum>()
                    .Select(e => new Role()
                    {
                        Id = e,
                        Name = e.ToString()
                    }));
        }
    }
}

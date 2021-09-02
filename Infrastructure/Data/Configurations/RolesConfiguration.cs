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
    class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(Enum.GetValues(typeof(RolesEnum))
                    .Cast<RolesEnum>()
                    .Select(e => new Roles()
                    {
                        Id = e,
                        Name = e.ToString()
                    }));
        }
    }
}

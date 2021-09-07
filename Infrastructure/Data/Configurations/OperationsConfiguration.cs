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
    class OperationsConfiguration : IEntityTypeConfiguration<Operations>
    {
        public void Configure(EntityTypeBuilder<Operations> builder)
        {
            builder.HasData(Enum.GetValues(typeof(OperationsEnum))
                    .Cast<OperationsEnum>()
                    .Select(e => new Operations()
                    {
                        Id = e,
                        Name = e.ToString()
                    }));
        }
    }
}

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
    class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasData(Enum.GetValues(typeof(OperationEnum))
                    .Cast<OperationEnum>()
                    .Select(e => new Operation()
                    {
                        Id = e,
                        Name = e.ToString()
                    }));
        }
    }
}

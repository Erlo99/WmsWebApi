using Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations.Views
{
    class UserOperationsViewConfiguration : IEntityTypeConfiguration<UserOperationsView>
    {

        public void Configure(EntityTypeBuilder<UserOperationsView> builder)
        {
            builder.HasNoKey().ToView("UserOperations_VV");
        }
    }
}

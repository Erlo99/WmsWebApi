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
    class UserStoresViewConfiguration : IEntityTypeConfiguration<UserStoresView>
    {

        public void Configure(EntityTypeBuilder<UserStoresView> builder)
        {
            builder.HasNoKey().ToView("UserStores_VV");
        }
    }
}

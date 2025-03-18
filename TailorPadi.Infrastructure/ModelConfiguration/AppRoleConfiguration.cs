using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorPadi.Data.Entities;

namespace TailorPadi.Infrastructure.ModelConfiguration;
public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new AppRole
            {
                Id = 1,
                Name = "Super Admin",
                NormalizedName = "Super Admin".ToUpper(),
            });
    }
}

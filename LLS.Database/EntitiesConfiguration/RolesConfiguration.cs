using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLS.Database.EntitiesConfiguration;

public class RolesConfiguration: IEntityTypeConfiguration<IdentityRole>
{

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new List<IdentityRole>()
        {
            new IdentityRole() { Name = "Admin", NormalizedName = "Admin" },
            new IdentityRole() { Name = "User", NormalizedName = "User" }
        });
    }
}
using LLS.Database.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLS.Database.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(150);
        builder.Property(x => x.Surname).HasMaxLength(150);
        builder.OwnsOne(a => a.Address, nb =>
        {
            nb.Property(x => x.Street).HasMaxLength(250).HasColumnName($"{nameof(Address)}_{nameof(Address.Street)}");
            nb.Property(x => x.BuildingNumber).HasMaxLength(10).HasColumnName($"{nameof(Address)}_{nameof(Address.BuildingNumber)}");
            nb.Property(x => x.City).HasMaxLength(150).HasColumnName($"{nameof(Address)}_{nameof(Address.City)}");
            nb.Property(x => x.Voivodeship).HasMaxLength(150).HasColumnName($"{nameof(Address)}_{nameof(Address.Voivodeship)}");
            nb.Property(x => x.Country).HasMaxLength(150).HasColumnName($"{nameof(Address)}_{nameof(Address.Country)}");
            nb.Property(x => x.ZipCode).HasMaxLength(10).HasColumnName($"{nameof(Address)}_{nameof(Address.ZipCode)}");
        });
    }
}
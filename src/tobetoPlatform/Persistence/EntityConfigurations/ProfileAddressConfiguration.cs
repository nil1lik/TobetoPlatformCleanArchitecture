using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileAddressConfiguration : IEntityTypeConfiguration<ProfileAddress>
{
    public void Configure(EntityTypeBuilder<ProfileAddress> builder)
    {
        builder.ToTable("ProfileAddresses").HasKey(pa => pa.Id);

        builder.Property(pa => pa.Id).HasColumnName("Id").IsRequired();
        builder.Property(pa => pa.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pa => pa.CityId).HasColumnName("CityId");
        builder.Property(pa => pa.AddressDetail).HasColumnName("AddressDetail");
        builder.Property(pa => pa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pa => pa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pa => pa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pa => !pa.DeletedDate.HasValue);
    }
}
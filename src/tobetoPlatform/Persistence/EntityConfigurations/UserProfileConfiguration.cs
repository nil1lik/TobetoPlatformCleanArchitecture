using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfiles").HasKey(up => up.Id);

        builder.Property(up => up.Id).HasColumnName("Id").IsRequired();
        builder.Property(up => up.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(up => up.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(up => up.DistrictId).HasColumnName("DistrictId").IsRequired();
        builder.Property(up => up.NationalIdentity).HasColumnName("NationalIdentity").IsRequired();
        builder.Property(up => up.Phone).HasColumnName("Phone").IsRequired();
        builder.Property(up => up.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(up => up.AddressDetail).HasColumnName("AddressDetail");
        builder.Property(up => up.Description).HasColumnName("Description");
        builder.Property(up => up.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(up => up.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(up => up.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(up => !up.DeletedDate.HasValue);
    }
}
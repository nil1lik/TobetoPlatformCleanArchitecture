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
        builder.Property(up => up.UserId).HasColumnName("UserId");
        builder.Property(up => up.ProfileAddressId).HasColumnName("ProfileAddressId");
        builder.Property(up => up.ProfileShareId).HasColumnName("ProfileShareId");
        builder.Property(up => up.NationalIdentity).HasColumnName("NationalIdentity");
        builder.Property(up => up.Phone).HasColumnName("Phone");
        builder.Property(up => up.BirthDate).HasColumnName("BirthDate");
        builder.Property(up => up.Description).HasColumnName("Description");
        builder.Property(up => up.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(up => up.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(up => up.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(up => !up.DeletedDate.HasValue);
    }
}
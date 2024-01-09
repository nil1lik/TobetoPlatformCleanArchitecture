using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileShareConfiguration : IEntityTypeConfiguration<ProfileShare>
{
    public void Configure(EntityTypeBuilder<ProfileShare> builder)
    {
        builder.ToTable("ProfileShares").HasKey(ps => ps.Id);

        builder.Property(ps => ps.Id).HasColumnName("Id").IsRequired();
        builder.Property(ps => ps.ProfileUrl).HasColumnName("ProfileUrl");
        builder.Property(ps => ps.IsShare).HasColumnName("IsShare");
        builder.Property(ps => ps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ps => ps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ps => ps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ps => !ps.DeletedDate.HasValue);
    }
}
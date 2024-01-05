using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoCategoryConfiguration : IEntityTypeConfiguration<VideoCategory>
{
    public void Configure(EntityTypeBuilder<VideoCategory> builder)
    {
        builder.ToTable("VideoCategories").HasKey(vc => vc.Id);

        builder.Property(vc => vc.Id).HasColumnName("Id").IsRequired();
        builder.Property(vc => vc.Name).HasColumnName("Name");
        builder.Property(vc => vc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(vc => vc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(vc => vc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(vc => !vc.DeletedDate.HasValue);
    }
}
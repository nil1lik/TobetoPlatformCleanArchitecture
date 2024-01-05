using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VideoLanguageConfiguration : IEntityTypeConfiguration<VideoLanguage>
{
    public void Configure(EntityTypeBuilder<VideoLanguage> builder)
    {
        builder.ToTable("VideoLanguages").HasKey(vl => vl.Id);

        builder.Property(vl => vl.Id).HasColumnName("Id").IsRequired();
        builder.Property(vl => vl.Name).HasColumnName("Name");
        builder.Property(vl => vl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(vl => vl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(vl => vl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(vl => !vl.DeletedDate.HasValue);
    }
}
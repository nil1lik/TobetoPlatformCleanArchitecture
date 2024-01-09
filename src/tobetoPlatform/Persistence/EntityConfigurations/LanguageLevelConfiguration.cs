using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LanguageLevelConfiguration : IEntityTypeConfiguration<LanguageLevel>
{
    public void Configure(EntityTypeBuilder<LanguageLevel> builder)
    {
        builder.ToTable("LanguageLevels").HasKey(ll => ll.Id);

        builder.Property(ll => ll.Id).HasColumnName("Id").IsRequired();
        builder.Property(ll => ll.Name).HasColumnName("Name").IsRequired();
        builder.Property(ll => ll.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ll => ll.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ll => ll.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ll => !ll.DeletedDate.HasValue);
    }
}
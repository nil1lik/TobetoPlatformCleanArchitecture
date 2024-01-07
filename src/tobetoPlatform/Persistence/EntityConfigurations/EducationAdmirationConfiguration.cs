using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationAdmirationConfiguration : IEntityTypeConfiguration<EducationAdmiration>
{
    public void Configure(EntityTypeBuilder<EducationAdmiration> builder)
    {
        builder.ToTable("EducationAdmirations").HasKey(ea => ea.Id);

        builder.Property(ea => ea.Id).HasColumnName("Id").IsRequired();
        builder.Property(ea => ea.IsLiked).HasColumnName("IsLiked");
        builder.Property(ea => ea.IsFavourited).HasColumnName("IsFavourited");
        builder.Property(ea => ea.CompletionRate).HasColumnName("CompletionRate");
        builder.Property(ea => ea.EducationPoint).HasColumnName("EducationPoint");
        builder.Property(ea => ea.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ea => ea.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ea => ea.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ea => !ea.DeletedDate.HasValue);
    }
}
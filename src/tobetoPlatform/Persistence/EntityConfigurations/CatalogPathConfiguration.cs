using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CatalogPathConfiguration : IEntityTypeConfiguration<CatalogPath>
{
    public void Configure(EntityTypeBuilder<CatalogPath> builder)
    {
        builder.ToTable("CatalogPaths").HasKey(cp => cp.Id);

        builder.Property(cp => cp.Id).HasColumnName("Id").IsRequired();
        builder.Property(cp => cp.Name).HasColumnName("Name");
        builder.Property(cp => cp.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(cp => cp.InstructorId).HasColumnName("InstructorId");
        builder.Property(cp => cp.Time).HasColumnName("Time");
        builder.Property(cp => cp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cp => cp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cp => cp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cp => !cp.DeletedDate.HasValue);
    }
}
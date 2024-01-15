using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.CityId).HasColumnName("CityId");
        builder.Property(e => e.OrganizationName).HasColumnName("OrganizationName").IsRequired();
        builder.Property(e => e.Position).HasColumnName("Position").IsRequired();
        builder.Property(e => e.Sector).HasColumnName("Sector").IsRequired();
        builder.Property(e => e.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(e => e.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}
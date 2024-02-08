using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationStepConfiguration : IEntityTypeConfiguration<ApplicationStep>
{
    public void Configure(EntityTypeBuilder<ApplicationStep> builder)
    {
        builder.ToTable("ApplicationSteps").HasKey(aps => aps.Id);

        builder.Property(aps => aps.Id).HasColumnName("Id").IsRequired();
        builder.Property(aps => aps.UserApplicationId).HasColumnName("UserApplicationId");
        builder.Property(aps => aps.Name).HasColumnName("Name");
        builder.Property(aps => aps.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aps => aps.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aps => aps.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(aps => !aps.DeletedDate.HasValue);
    }
}
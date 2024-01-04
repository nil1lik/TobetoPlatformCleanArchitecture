using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationStepConfiguration : IEntityTypeConfiguration<ApplicationStep>
{
    public void Configure(EntityTypeBuilder<ApplicationStep> builder)
    {
        builder.ToTable("ApplicationSteps").HasKey(as => as.Id);

        builder.Property(as => as.Id).HasColumnName("Id").IsRequired();
        builder.Property(as => as.UserApplicationId).HasColumnName("UserApplicationId");
        builder.Property(as => as.Name).HasColumnName("Name");
        builder.Property(as => as.DocumentUrl).HasColumnName("DocumentUrl");
        builder.Property(as => as.FormUrl).HasColumnName("FormUrl");
        builder.Property(as => as.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(as => as.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(as => as.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(as => !as.DeletedDate.HasValue);
    }
}
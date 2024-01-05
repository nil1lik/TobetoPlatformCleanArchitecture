using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileApplicationStepConfiguration : IEntityTypeConfiguration<ProfileApplicationStep>
{
    public void Configure(EntityTypeBuilder<ProfileApplicationStep> builder)
    {
        builder.ToTable("ProfileApplicationSteps").HasKey(pas => pas.Id);

        builder.Property(pas => pas.Id).HasColumnName("Id").IsRequired();
        //builder.Property(pas => pas.ApplicationStepId).HasColumnName("ApplicationStepId");
        builder.Property(pas => pas.ProfileApplicationId).HasColumnName("ProfileApplicationId");
        builder.Property(pas => pas.IsCompleted).HasColumnName("IsCompleted");
        builder.Property(pas => pas.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pas => pas.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pas => pas.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pas => !pas.DeletedDate.HasValue);
    }
}
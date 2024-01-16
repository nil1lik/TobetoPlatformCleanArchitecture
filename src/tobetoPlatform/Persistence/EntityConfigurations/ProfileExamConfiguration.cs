using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileExamConfiguration : IEntityTypeConfiguration<ProfileExam>
{
    public void Configure(EntityTypeBuilder<ProfileExam> builder)
    {
        builder.ToTable("ProfileExams").HasKey(pe => pe.Id);

        builder.Property(pe => pe.Id).HasColumnName("Id").IsRequired();
        builder.Property(pe => pe.UserProfileId).HasColumnName("UserProfileId");
        builder.Property(pe => pe.ExamId).HasColumnName("ExamId");
        builder.Property(pe => pe.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pe => pe.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pe => pe.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pe => !pe.DeletedDate.HasValue);
    }
}
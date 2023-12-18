using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
{
    public void Configure(EntityTypeBuilder<ExamResult> builder)
    {
        builder.ToTable("ExamResults").HasKey(er => er.Id);

        builder.Property(er => er.Id).HasColumnName("Id").IsRequired();
        builder.Property(er => er.ExamStatusId).HasColumnName("ExamStatusId");
        builder.Property(er => er.Correct).HasColumnName("Correct");
        builder.Property(er => er.Wrong).HasColumnName("Wrong");
        builder.Property(er => er.Empty).HasColumnName("Empty");
        builder.Property(er => er.Point).HasColumnName("Point");
        builder.Property(er => er.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(er => er.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(er => er.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(er => !er.DeletedDate.HasValue);
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProfileApplicationFormConfiguration : IEntityTypeConfiguration<ProfileApplicationForm>
{
    public void Configure(EntityTypeBuilder<ProfileApplicationForm> builder)
    {
        builder.ToTable("ProfileApplicationForms").HasKey(paf => paf.Id);

        builder.Property(paf => paf.Id).HasColumnName("Id").IsRequired();
        builder.Property(paf => paf.ApplicationFormId).HasColumnName("ApplicationFormId");
        builder.Property(paf => paf.Name).HasColumnName("Name");
        builder.Property(paf => paf.ApprovalStatus).HasColumnName("ApprovalStatus");
        builder.Property(paf => paf.Message).HasColumnName("Message");
        builder.Property(paf => paf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(paf => paf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(paf => paf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(paf => !paf.DeletedDate.HasValue);
    }
}
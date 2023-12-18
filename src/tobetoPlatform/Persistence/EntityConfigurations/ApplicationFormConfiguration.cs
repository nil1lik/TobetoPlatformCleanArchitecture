using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ApplicationFormConfiguration : IEntityTypeConfiguration<ApplicationForm>
{
    public void Configure(EntityTypeBuilder<ApplicationForm> builder)
    {
        builder.ToTable("ApplicationForms").HasKey(af => af.Id);

        builder.Property(af => af.Id).HasColumnName("Id").IsRequired();
        builder.Property(af => af.ProfileDocumentFormId).HasColumnName("ProfileDocumentFormId");
        builder.Property(af => af.ProfileApplicationFormId).HasColumnName("ProfileApplicationFormId");
        builder.Property(af => af.Name).HasColumnName("Name");
        builder.Property(af => af.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(af => af.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(af => af.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(af => !af.DeletedDate.HasValue);
    }
}
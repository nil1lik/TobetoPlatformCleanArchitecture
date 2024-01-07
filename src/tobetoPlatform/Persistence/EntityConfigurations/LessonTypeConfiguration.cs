using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonTypeConfiguration : IEntityTypeConfiguration<LessonType>
{
    public void Configure(EntityTypeBuilder<LessonType> builder)
    {
        builder.ToTable("LessonTypes").HasKey(lt => lt.Id);

        builder.Property(lt => lt.Id).HasColumnName("Id").IsRequired();
        builder.Property(lt => lt.Name).HasColumnName("Name");
        builder.Property(lt => lt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lt => lt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lt => lt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lt => !lt.DeletedDate.HasValue);
    }
}
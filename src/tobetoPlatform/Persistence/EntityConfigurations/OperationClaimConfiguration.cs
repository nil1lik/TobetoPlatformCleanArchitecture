using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Skills
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Delete" });
        #endregion
        #region Exams
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Delete" });
        #endregion
        #region Cities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
        #endregion
        #region Countries
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Delete" });
        #endregion
        #region Districts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        #endregion
        #region CourseClasses
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseClasses.Delete" });
        #endregion
        #region LanguageLevels
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Delete" });
        #endregion
        return seeds;
        
    }
}

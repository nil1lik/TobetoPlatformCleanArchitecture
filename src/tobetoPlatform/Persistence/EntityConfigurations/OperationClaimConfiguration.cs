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
        #region ApplicationForms
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationForms.Delete" });
        #endregion
        
        #region AsyncLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AsyncLessons.Delete" });
        #endregion
        #region Calendars
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Calendars.Delete" });
        #endregion
        #region Certificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Delete" });
        #endregion
        #region Companies
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Delete" });
        #endregion
        #region Contacts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contacts.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region CourseInstructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Delete" });
        #endregion
        #region CourseLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLessons.Delete" });
        #endregion
        #region EducationAbouts
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAbouts.Delete" });
        #endregion
        #region EducationAboutCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAboutCategories.Delete" });
        #endregion
        #region EducationAdmirations
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationAdmirations.Delete" });
        #endregion
        #region EducationPaths
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPaths.Delete" });
        #endregion
        #region ExamResults
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamResults.Delete" });
        #endregion
        #region Experiences
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region LessonTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTypes.Delete" });
        #endregion
        #region LessonVideoDetails
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetails.Delete" });
        #endregion
        #region UserProfiles
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserProfiles.Delete" });
        #endregion
        #region ProfileApplications
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplications.Delete" });
        #endregion
        #region ProfileApplicationForms
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationForms.Delete" });
        #endregion
        return seeds;
    }
}

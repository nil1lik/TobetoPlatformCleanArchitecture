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
        #region ProfileShares
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileShares.Delete" });
        #endregion
        #region Announcements
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Delete" });
        #endregion
        #region ApplicationSteps
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ApplicationSteps.Delete" });
        #endregion
        #region SyncLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SyncLessons.Delete" });
        #endregion
        #region Surveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Delete" });
        #endregion
        #region ProfileApplicationSteps
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileApplicationSteps.Delete" });
        #endregion
        #region VideoDetailSubcategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailSubcategories.Delete" });
        #endregion
        #region VideoLanguages
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoLanguages.Delete" });
        #endregion
        #region UserApplications
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "UserApplications.Delete" });
        #endregion
        #region Graduations
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Graduations.Delete" });
        #endregion
        #region Languages
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Delete" });
        #endregion
        #region VideoCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoCategories.Delete" });
        #endregion
        #region SocialMediaAccounts
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaAccounts.Delete" });
        #endregion
        #region SocialMediaCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaCategories.Delete" });
        #endregion
        #region ProfileAddresses
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileAddresses.Delete" });
        #endregion
        #region AnnouncementTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Delete" });
        #endregion
        #region ProfileExams
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileExams.Delete" });
        #endregion
        #region VideoDetailCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "VideoDetailCategories.Delete" });
        #endregion
        #region ProfileGraduations
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileGraduations.Delete" });
        #endregion
        #region ProfileSkills
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileSkills.Delete" });
        #endregion
        #region ProfileLanguages
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLanguages.Delete" });
        #endregion

        
        #region LessonVideoDetailVideoDetailCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonVideoDetailVideoDetailCategories.Delete" });
        #endregion
        #region ProfileEducations
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileEducations.Delete" });
        #endregion
        #region CatalogPaths
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CatalogPaths.Delete" });
        #endregion
        #region ProfileLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ProfileLessons.Delete" });
        #endregion
        return seeds;
    }
}

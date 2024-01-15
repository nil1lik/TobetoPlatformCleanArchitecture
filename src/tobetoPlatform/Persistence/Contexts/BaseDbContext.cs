using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<CourseClass> CourseClasses { get; set; }
    public DbSet<AsyncLesson> AsyncLessons { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseInstructor> CourseInstructors { get; set; }
    public DbSet<CourseLesson> CourseLessons { get; set; }
    public DbSet<EducationAbout> EducationAbouts { get; set; }
    public DbSet<EducationAboutCategory> EducationAboutCategories { get; set; }
    public DbSet<EducationAdmiration> EducationAdmirations { get; set; }
    public DbSet<EducationPath> EducationPaths { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<LessonType> LessonTypes { get; set; }
    public DbSet<LessonVideoDetail> LessonVideoDetails { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<ProfileApplication> ProfileApplications { get; set; }
    public DbSet<LanguageLevel> LanguageLevels { get; set; }
    public DbSet<ProfileShare> ProfileShares { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<ApplicationStep> ApplicationSteps { get; set; }
    public DbSet<SyncLesson> SyncLessons { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<ProfileApplicationStep> ProfileApplicationSteps { get; set; }
    public DbSet<VideoDetailSubcategory> VideoDetailSubcategories { get; set; }
    public DbSet<VideoLanguage> VideoLanguages { get; set; }
    public DbSet<UserApplication> UserApplications { get; set; }
    public DbSet<Graduation> Graduations { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<VideoCategory> VideoCategories { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<SocialMediaCategory> SocialMediaCategories { get; set; }
    public DbSet<AnnouncementType> AnnouncementTypes { get; set; }



    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

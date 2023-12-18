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
    public DbSet<ApplicationForm> ApplicationForms { get; set; }
    public DbSet<AsyncLesson> AsyncLessons { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
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
    public DbSet<UserProfile> Profiles { get; set; }


    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

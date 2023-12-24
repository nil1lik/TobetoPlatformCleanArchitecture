using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IAsyncLessonRepository, AsyncLessonRepository>();
        services.AddScoped<ICalendarRepository, CalendarRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseClassRepository, CourseClassRepository>();
        services.AddScoped<ICourseInstructorRepository, CourseInstructorRepository>();
        services.AddScoped<ICourseLessonRepository, CourseLessonRepository>();
        services.AddScoped<IEducationAboutRepository, EducationAboutRepository>();
        services.AddScoped<IEducationAboutCategoryRepository, EducationAboutCategoryRepository>();
        services.AddScoped<IEducationAdmirationRepository, EducationAdmirationRepository>();
        services.AddScoped<IEducationPathRepository, EducationPathRepository>();
        services.AddScoped<IExamResultRepository, ExamResultRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IGraduationRepository, GraduationRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ILessonTypeRepository, LessonTypeRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ILanguageLevelRepository, LanguageLevelRepository>();
        services.AddScoped<ILessonVideoDetailRepository, LessonVideoDetailRepository>();

        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<IProfileApplicationRepository, ProfileApplicationRepository>();
        return services;
    }
}

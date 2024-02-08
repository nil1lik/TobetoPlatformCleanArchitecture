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
        services.AddDbContext<BaseDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformConnectionString")));
        //options.UseInMemoryDatabase("inMemory"));
        

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();


        services.AddScoped<IProfileShareRepository, ProfileShareRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IProfileApplicationRepository, ProfileApplicationRepository>();
        services.AddScoped<IApplicationStepRepository, ApplicationStepRepository>();
        services.AddScoped<IAsyncLessonRepository, AsyncLessonRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseClassRepository, CourseClassRepository>();
        services.AddScoped<ISyncLessonRepository, SyncLessonRepository>();
        services.AddScoped<IExamResultRepository, ExamResultRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<IEducationAboutCategoryRepository, EducationAboutCategoryRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<ILessonTypeRepository, LessonTypeRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IProfileApplicationStepRepository, ProfileApplicationStepRepository>();
        services.AddScoped<IEducationPathRepository, EducationPathRepository>();
        services.AddScoped<IVideoDetailSubcategoryRepository, VideoDetailSubcategoryRepository>();
        services.AddScoped<IVideoLanguageRepository, VideoLanguageRepository>();
        services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();
        services.AddScoped<IEducationAdmirationRepository, EducationAdmirationRepository>();
        services.AddScoped<ILanguageLevelRepository, LanguageLevelRepository>();
        services.AddScoped<IEducationAboutRepository, EducationAboutRepository>();
        services.AddScoped<IGraduationRepository, GraduationRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IVideoCategoryRepository, VideoCategoryRepository>();
        services.AddScoped<ISocialMediaAccountRepository, SocialMediaAccountRepository>();
        services.AddScoped<ISocialMediaCategoryRepository, SocialMediaCategoryRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IProfileAddressRepository, ProfileAddressRepository>();
        services.AddScoped<IAnnouncementTypeRepository, AnnouncementTypeRepository>();
        services.AddScoped<IProfileExamRepository, ProfileExamRepository>();
        services.AddScoped<ICourseInstructorRepository, CourseInstructorRepository>();
        services.AddScoped<ILessonVideoDetailRepository, LessonVideoDetailRepository>();
        return services;

    }
}

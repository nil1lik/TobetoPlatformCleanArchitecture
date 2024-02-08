using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Domain.Entities;
using Application.Services.ProfileShares;
using Application.Services.ProfileApplications;
using Application.Services.ApplicationSteps;
using Application.Services.AsyncLessons;
using Application.Services.Certificates;
using Application.Services.Cities;
using Application.Services.Companies;
using Application.Services.Contacts;
using Application.Services.Courses;
using Application.Services.CourseClasses;
using Application.Services.SyncLessons;
using Application.Services.ExamResults;
using Application.Services.Instructors;
using Application.Services.EducationAboutCategories;
using Application.Services.Districts;
using Application.Services.LessonTypes;
using Application.Services.Skills;
using Application.Services.Surveys;
using Application.Services.Exams;
using Application.Services.ProfileApplicationSteps;
using Application.Services.EducationPaths;
using Application.Services.VideoDetailSubcategories;
using Application.Services.VideoLanguages;
using Application.Services.UserApplications;
using Application.Services.EducationAdmirations;
using Application.Services.LanguageLevels;
using Application.Services.EducationAbouts;
using Application.Services.Graduations;
using Application.Services.Languages;
using Application.Services.VideoCategories;
using Application.Services.SocialMediaAccounts;
using Application.Services.SocialMediaCategories;
using Application.Services.UserProfiles;
using Application.Services.Announcements;
using Application.Services.Experiences;
using Application.Services.ProfileAddresses;
using Application.Services.AnnouncementTypes;
using Application.Services.CourseInstructors;
using Application.Services.LessonVideoDetails;


namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IProfileSharesService, ProfileSharesManager>();
        services.AddScoped<IProfileApplicationsService, ProfileApplicationsManager>();
        services.AddScoped<IApplicationStepsService, ApplicationStepsManager>();
        services.AddScoped<IAsyncLessonsService, AsyncLessonsManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<ICitiesService, CitiesManager>();
        services.AddScoped<ICompaniesService, CompaniesManager>();
        services.AddScoped<IContactsService, ContactsManager>();
        services.AddScoped<ICoursesService, CoursesManager>();
        services.AddScoped<ICourseClassesService, CourseClassesManager>();
        services.AddScoped<ISyncLessonsService, SyncLessonsManager>();
        services.AddScoped<IExamResultsService, ExamResultsManager>();
        services.AddScoped<IUserProfilesService, UserProfilesManager>();
        services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
        services.AddScoped<IExperiencesService, ExperiencesManager>();
        services.AddScoped<IProfileAddressesService, ProfileAddressesManager>();
        services.AddScoped<IAnnouncementTypesService, AnnouncementTypesManager>();
        services.AddScoped<ICourseInstructorsService, CourseInstructorsManager>();
        services.AddScoped<ILessonVideoDetailsService, LessonVideoDetailsManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}

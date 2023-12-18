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
using Application.Services.Skills;
using Application.Services.Exams;
using Application.Services.Cities;
using Application.Services.Countries;
using Application.Services.Districts;
using Application.Services.Announcements;
using Application.Services.CourseClasses;
using Application.Services.ApplicationForms;
using Application.Services.AsyncLessons;
using Application.Services.Calendars;
using Application.Services.Certificates;
using Application.Services.Companies;
using Application.Services.Contacts;
using Application.Services.Courses;
using Application.Services.CourseInstructors;
using Application.Services.CourseLessons;
using Application.Services.EducationAbouts;
using Application.Services.EducationAboutCategories;
using Application.Services.EducationAdmirations;
using Application.Services.EducationPaths;
using Application.Services.ExamResults;
using Application.Services.Experiences;
using Application.Services.Instructors;
using Application.Services.LessonTypes;
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

        services.AddScoped<ISkillsService, SkillsManager>();
        services.AddScoped<IExamsService, ExamsManager>();


        services.AddScoped<ICitiesService, CitiesManager>();
        services.AddScoped<ICountriesService, CountriesManager>();
        services.AddScoped<IDistrictsService, DistrictsManager>();

        services.AddScoped<ICourseClassesService, CourseClassesManager>();

        services.AddScoped<IApplicationFormsService, ApplicationFormsManager>();
        services.AddScoped<IAsyncLessonsService, AsyncLessonsManager>();
        services.AddScoped<ICalendarsService, CalendarsManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<ICompaniesService, CompaniesManager>();
        services.AddScoped<IContactsService, ContactsManager>();
        services.AddScoped<ICoursesService, CoursesManager>();
        services.AddScoped<ICourseInstructorsService, CourseInstructorsManager>();
        services.AddScoped<ICourseLessonsService, CourseLessonsManager>();
        services.AddScoped<IEducationAboutsService, EducationAboutsManager>();
        services.AddScoped<IEducationAboutCategoriesService, EducationAboutCategoriesManager>();
        services.AddScoped<IEducationAdmirationsService, EducationAdmirationsManager>();
        services.AddScoped<IEducationPathsService, EducationPathsManager>();
        services.AddScoped<IExamResultsService, ExamResultsManager>();
        services.AddScoped<IExperiencesService, ExperiencesManager>();
        services.AddScoped<IInstructorsService, InstructorsManager>();
        services.AddScoped<ILessonTypesService, LessonTypesManager>();
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

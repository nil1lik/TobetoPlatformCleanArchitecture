using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Courses.Queries.GetAsyncLessonsByCourseId;

namespace Application.Features.Courses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, CreatedCourseResponse>().ReverseMap();
        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdatedCourseResponse>().ReverseMap();
        CreateMap<Course, DeleteCourseCommand>().ReverseMap();
        CreateMap<Course, DeletedCourseResponse>().ReverseMap();
        CreateMap<Course, GetByIdCourseResponse>().ReverseMap();
        CreateMap<Course, GetListCourseListItemDto>().ReverseMap();

        CreateMap<Course, GetAsyncLessonsByCourseIdResponse>()
    .ForMember(dest => dest.AsyncLessons, opt => opt.MapFrom(src => src.CourseLesson.Select(cl => new GetAsyncLessonsByCourseIdItem
    {
        Id = cl.AsyncLesson.Id,
        Name = cl.AsyncLesson.Name,
        LessonType = cl.AsyncLesson.LessonType.Name,
        Time = cl.AsyncLesson.Time
    })));





        CreateMap<IPaginate<Course>, GetListResponse<GetListCourseListItemDto>>().ReverseMap();


    }

    private static DateTime GetSessionStartDate(Course source)
    {
        // �zel d�n���m logic'i burada
        // SessionStartDate'� almak i�in uygun d�n���m i�lemini ger�ekle�tirin

        var sessionStartDate = source.SyncLessons
            .OrderBy(sl => sl.StartDate)  // �rnek: �lk ba�lang�� tarihini se�
            .Select(sl => sl.StartDate)
            .FirstOrDefault();

        return sessionStartDate;
    }
}
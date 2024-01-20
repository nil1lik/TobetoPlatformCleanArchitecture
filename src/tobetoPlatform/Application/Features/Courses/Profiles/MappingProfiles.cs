using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Courses.Queries.GetCalendarDetailList;

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
        CreateMap<Course, GetCalendarDetailListDto>().
                                    ForMember(p => p.InstructorFirstName, opt => opt.MapFrom(p => p.CourseInstructors.Select(p => p.Instructor.FirstName))).
                                    ForMember(p => p.InstructorLastName,  opt => opt.MapFrom(p => p.CourseInstructors.Select(p => p.Instructor.LastName))).
                                    ForMember(p => p.SessionName,         opt => opt.MapFrom(p => p.SyncLessons.Select(p => p.SessionName))).
                                    ForMember(p => p.SessionStartDate,    opt => opt.MapFrom(p => p.SyncLessons.Select(p => p.StartDate)))
                                    .ReverseMap();
        CreateMap<IPaginate<Course>, GetListResponse<GetListCourseListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Course>, GetListResponse<GetCalendarDetailListDto>>().ReverseMap();


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
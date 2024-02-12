using Application.Features.CourseLessons.Commands.Create;
using Application.Features.CourseLessons.Commands.Delete;
using Application.Features.CourseLessons.Commands.Update;
using Application.Features.CourseLessons.Queries.GetById;
using Application.Features.CourseLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseLesson, CreateCourseLessonCommand>().ReverseMap();
        CreateMap<CourseLesson, CreatedCourseLessonResponse>().ReverseMap();
        CreateMap<CourseLesson, UpdateCourseLessonCommand>().ReverseMap();
        CreateMap<CourseLesson, UpdatedCourseLessonResponse>().ReverseMap();
        CreateMap<CourseLesson, DeleteCourseLessonCommand>().ReverseMap();
        CreateMap<CourseLesson, DeletedCourseLessonResponse>().ReverseMap();
        CreateMap<CourseLesson, GetByIdCourseLessonResponse>().ReverseMap();
        CreateMap<CourseLesson, GetListCourseLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseLesson>, GetListResponse<GetListCourseLessonListItemDto>>().ReverseMap();
    }
}
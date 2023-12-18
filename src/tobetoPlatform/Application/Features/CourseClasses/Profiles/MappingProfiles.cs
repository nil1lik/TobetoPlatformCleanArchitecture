using Application.Features.CourseClasses.Commands.Create;
using Application.Features.CourseClasses.Commands.Delete;
using Application.Features.CourseClasses.Commands.Update;
using Application.Features.CourseClasses.Queries.GetById;
using Application.Features.CourseClasses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseClasses.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseClass, CreateCourseClassCommand>().ReverseMap();
        CreateMap<CourseClass, CreatedCourseClassResponse>().ReverseMap();
        CreateMap<CourseClass, UpdateCourseClassCommand>().ReverseMap();
        CreateMap<CourseClass, UpdatedCourseClassResponse>().ReverseMap();
        CreateMap<CourseClass, DeleteCourseClassCommand>().ReverseMap();
        CreateMap<CourseClass, DeletedCourseClassResponse>().ReverseMap();
        CreateMap<CourseClass, GetByIdCourseClassResponse>().ReverseMap();
        CreateMap<CourseClass, GetListCourseClassListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseClass>, GetListResponse<GetListCourseClassListItemDto>>().ReverseMap();
    }
}
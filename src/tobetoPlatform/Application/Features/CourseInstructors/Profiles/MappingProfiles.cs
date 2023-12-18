using Application.Features.CourseInstructors.Commands.Create;
using Application.Features.CourseInstructors.Commands.Delete;
using Application.Features.CourseInstructors.Commands.Update;
using Application.Features.CourseInstructors.Queries.GetById;
using Application.Features.CourseInstructors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseInstructors.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseInstructor, CreateCourseInstructorCommand>().ReverseMap();
        CreateMap<CourseInstructor, CreatedCourseInstructorResponse>().ReverseMap();
        CreateMap<CourseInstructor, UpdateCourseInstructorCommand>().ReverseMap();
        CreateMap<CourseInstructor, UpdatedCourseInstructorResponse>().ReverseMap();
        CreateMap<CourseInstructor, DeleteCourseInstructorCommand>().ReverseMap();
        CreateMap<CourseInstructor, DeletedCourseInstructorResponse>().ReverseMap();
        CreateMap<CourseInstructor, GetByIdCourseInstructorResponse>().ReverseMap();
        CreateMap<CourseInstructor, GetListCourseInstructorListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseInstructor>, GetListResponse<GetListCourseInstructorListItemDto>>().ReverseMap();
    }
}
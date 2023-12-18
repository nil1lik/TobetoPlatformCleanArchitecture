using Application.Features.LessonTypes.Commands.Create;
using Application.Features.LessonTypes.Commands.Delete;
using Application.Features.LessonTypes.Commands.Update;
using Application.Features.LessonTypes.Queries.GetById;
using Application.Features.LessonTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LessonTypes.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonType, CreateLessonTypeCommand>().ReverseMap();
        CreateMap<LessonType, CreatedLessonTypeResponse>().ReverseMap();
        CreateMap<LessonType, UpdateLessonTypeCommand>().ReverseMap();
        CreateMap<LessonType, UpdatedLessonTypeResponse>().ReverseMap();
        CreateMap<LessonType, DeleteLessonTypeCommand>().ReverseMap();
        CreateMap<LessonType, DeletedLessonTypeResponse>().ReverseMap();
        CreateMap<LessonType, GetByIdLessonTypeResponse>().ReverseMap();
        CreateMap<LessonType, GetListLessonTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonType>, GetListResponse<GetListLessonTypeListItemDto>>().ReverseMap();
    }
}
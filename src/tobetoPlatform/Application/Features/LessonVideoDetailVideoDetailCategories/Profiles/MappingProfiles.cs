using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Create;
using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Delete;
using Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Update;
using Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetById;
using Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonVideoDetailVideoDetailCategory, CreateLessonVideoDetailVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, CreatedLessonVideoDetailVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, UpdateLessonVideoDetailVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, UpdatedLessonVideoDetailVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, DeleteLessonVideoDetailVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, DeletedLessonVideoDetailVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, GetByIdLessonVideoDetailVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<LessonVideoDetailVideoDetailCategory, GetListLessonVideoDetailVideoDetailCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonVideoDetailVideoDetailCategory>, GetListResponse<GetListLessonVideoDetailVideoDetailCategoryListItemDto>>().ReverseMap();
    }
}
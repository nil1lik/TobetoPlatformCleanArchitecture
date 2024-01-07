using Application.Features.EducationAboutCategories.Commands.Create;
using Application.Features.EducationAboutCategories.Commands.Delete;
using Application.Features.EducationAboutCategories.Commands.Update;
using Application.Features.EducationAboutCategories.Queries.GetById;
using Application.Features.EducationAboutCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EducationAboutCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationAboutCategory, CreateEducationAboutCategoryCommand>().ReverseMap();
        CreateMap<EducationAboutCategory, CreatedEducationAboutCategoryResponse>().ReverseMap();
        CreateMap<EducationAboutCategory, UpdateEducationAboutCategoryCommand>().ReverseMap();
        CreateMap<EducationAboutCategory, UpdatedEducationAboutCategoryResponse>().ReverseMap();
        CreateMap<EducationAboutCategory, DeleteEducationAboutCategoryCommand>().ReverseMap();
        CreateMap<EducationAboutCategory, DeletedEducationAboutCategoryResponse>().ReverseMap();
        CreateMap<EducationAboutCategory, GetByIdEducationAboutCategoryResponse>().ReverseMap();
        CreateMap<EducationAboutCategory, GetListEducationAboutCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<EducationAboutCategory>, GetListResponse<GetListEducationAboutCategoryListItemDto>>().ReverseMap();
    }
}
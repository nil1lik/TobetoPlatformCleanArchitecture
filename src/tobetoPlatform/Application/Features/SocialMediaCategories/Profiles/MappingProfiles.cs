using Application.Features.SocialMediaCategories.Commands.Create;
using Application.Features.SocialMediaCategories.Commands.Delete;
using Application.Features.SocialMediaCategories.Commands.Update;
using Application.Features.SocialMediaCategories.Queries.GetById;
using Application.Features.SocialMediaCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SocialMediaCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SocialMediaCategory, CreateSocialMediaCategoryCommand>().ReverseMap();
        CreateMap<SocialMediaCategory, CreatedSocialMediaCategoryResponse>().ReverseMap();
        CreateMap<SocialMediaCategory, UpdateSocialMediaCategoryCommand>().ReverseMap();
        CreateMap<SocialMediaCategory, UpdatedSocialMediaCategoryResponse>().ReverseMap();
        CreateMap<SocialMediaCategory, DeleteSocialMediaCategoryCommand>().ReverseMap();
        CreateMap<SocialMediaCategory, DeletedSocialMediaCategoryResponse>().ReverseMap();
        CreateMap<SocialMediaCategory, GetByIdSocialMediaCategoryResponse>().ReverseMap();
        CreateMap<SocialMediaCategory, GetListSocialMediaCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<SocialMediaCategory>, GetListResponse<GetListSocialMediaCategoryListItemDto>>().ReverseMap();
    }
}
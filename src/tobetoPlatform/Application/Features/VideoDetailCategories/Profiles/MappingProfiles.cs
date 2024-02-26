using Application.Features.VideoDetailCategories.Commands.Create;
using Application.Features.VideoDetailCategories.Commands.Delete;
using Application.Features.VideoDetailCategories.Commands.Update;
using Application.Features.VideoDetailCategories.Queries.GetById;
using Application.Features.VideoDetailCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.VideoDetailCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<VideoDetailCategory, CreateVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<VideoDetailCategory, CreatedVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<VideoDetailCategory, UpdateVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<VideoDetailCategory, UpdatedVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<VideoDetailCategory, DeleteVideoDetailCategoryCommand>().ReverseMap();
        CreateMap<VideoDetailCategory, DeletedVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<VideoDetailCategory, GetByIdVideoDetailCategoryResponse>().ReverseMap();
        CreateMap<VideoDetailCategory, GetListVideoDetailCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<VideoDetailCategory>, GetListResponse<GetListVideoDetailCategoryListItemDto>>().ReverseMap();
    }
}
using Application.Features.VideoDetailSubcategories.Commands.Create;
using Application.Features.VideoDetailSubcategories.Commands.Delete;
using Application.Features.VideoDetailSubcategories.Commands.Update;
using Application.Features.VideoDetailSubcategories.Queries.GetById;
using Application.Features.VideoDetailSubcategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.VideoDetailSubcategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<VideoDetailSubcategory, CreateVideoDetailSubcategoryCommand>().ReverseMap();
        CreateMap<VideoDetailSubcategory, CreatedVideoDetailSubcategoryResponse>().ReverseMap();
        CreateMap<VideoDetailSubcategory, UpdateVideoDetailSubcategoryCommand>().ReverseMap();
        CreateMap<VideoDetailSubcategory, UpdatedVideoDetailSubcategoryResponse>().ReverseMap();
        CreateMap<VideoDetailSubcategory, DeleteVideoDetailSubcategoryCommand>().ReverseMap();
        CreateMap<VideoDetailSubcategory, DeletedVideoDetailSubcategoryResponse>().ReverseMap();
        CreateMap<VideoDetailSubcategory, GetByIdVideoDetailSubcategoryResponse>().ReverseMap();
        CreateMap<VideoDetailSubcategory, GetListVideoDetailSubcategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<VideoDetailSubcategory>, GetListResponse<GetListVideoDetailSubcategoryListItemDto>>().ReverseMap();
    }
}
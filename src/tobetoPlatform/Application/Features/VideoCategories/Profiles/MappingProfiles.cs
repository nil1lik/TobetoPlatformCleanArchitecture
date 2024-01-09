using Application.Features.VideoCategories.Commands.Create;
using Application.Features.VideoCategories.Commands.Delete;
using Application.Features.VideoCategories.Commands.Update;
using Application.Features.VideoCategories.Queries.GetById;
using Application.Features.VideoCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.VideoCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<VideoCategory, CreateVideoCategoryCommand>().ReverseMap();
        CreateMap<VideoCategory, CreatedVideoCategoryResponse>().ReverseMap();
        CreateMap<VideoCategory, UpdateVideoCategoryCommand>().ReverseMap();
        CreateMap<VideoCategory, UpdatedVideoCategoryResponse>().ReverseMap();
        CreateMap<VideoCategory, DeleteVideoCategoryCommand>().ReverseMap();
        CreateMap<VideoCategory, DeletedVideoCategoryResponse>().ReverseMap();
        CreateMap<VideoCategory, GetByIdVideoCategoryResponse>().ReverseMap();
        CreateMap<VideoCategory, GetListVideoCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<VideoCategory>, GetListResponse<GetListVideoCategoryListItemDto>>().ReverseMap();
    }
}
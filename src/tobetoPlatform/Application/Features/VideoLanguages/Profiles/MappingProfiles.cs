using Application.Features.VideoLanguages.Commands.Create;
using Application.Features.VideoLanguages.Commands.Delete;
using Application.Features.VideoLanguages.Commands.Update;
using Application.Features.VideoLanguages.Queries.GetById;
using Application.Features.VideoLanguages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.VideoLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<VideoLanguage, CreateVideoLanguageCommand>().ReverseMap();
        CreateMap<VideoLanguage, CreatedVideoLanguageResponse>().ReverseMap();
        CreateMap<VideoLanguage, UpdateVideoLanguageCommand>().ReverseMap();
        CreateMap<VideoLanguage, UpdatedVideoLanguageResponse>().ReverseMap();
        CreateMap<VideoLanguage, DeleteVideoLanguageCommand>().ReverseMap();
        CreateMap<VideoLanguage, DeletedVideoLanguageResponse>().ReverseMap();
        CreateMap<VideoLanguage, GetByIdVideoLanguageResponse>().ReverseMap();
        CreateMap<VideoLanguage, GetListVideoLanguageListItemDto>().ReverseMap();
        CreateMap<IPaginate<VideoLanguage>, GetListResponse<GetListVideoLanguageListItemDto>>().ReverseMap();
    }
}
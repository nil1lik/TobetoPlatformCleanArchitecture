using Application.Features.LanguageLevels.Commands.Create;
using Application.Features.LanguageLevels.Commands.Delete;
using Application.Features.LanguageLevels.Commands.Update;
using Application.Features.LanguageLevels.Queries.GetById;
using Application.Features.LanguageLevels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LanguageLevels.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<LanguageLevel, CreateLanguageLevelCommand>().ReverseMap();
        CreateMap<LanguageLevel, CreatedLanguageLevelResponse>().ReverseMap();
        CreateMap<LanguageLevel, UpdateLanguageLevelCommand>().ReverseMap();
        CreateMap<LanguageLevel, UpdatedLanguageLevelResponse>().ReverseMap();
        CreateMap<LanguageLevel, DeleteLanguageLevelCommand>().ReverseMap();
        CreateMap<LanguageLevel, DeletedLanguageLevelResponse>().ReverseMap();
        CreateMap<LanguageLevel, GetByIdLanguageLevelResponse>().ReverseMap();
        CreateMap<LanguageLevel, GetListLanguageLevelListItemDto>().ReverseMap();
        CreateMap<IPaginate<LanguageLevel>, GetListResponse<GetListLanguageLevelListItemDto>>().ReverseMap();
    }
}
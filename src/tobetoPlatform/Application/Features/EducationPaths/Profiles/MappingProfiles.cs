using Application.Features.EducationPaths.Commands.Create;
using Application.Features.EducationPaths.Commands.Delete;
using Application.Features.EducationPaths.Commands.Update;
using Application.Features.EducationPaths.Queries.GetById;
using Application.Features.EducationPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EducationPaths.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationPath, CreateEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, CreatedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, UpdateEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, UpdatedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, DeleteEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, DeletedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, GetByIdEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, GetListEducationPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<EducationPath>, GetListResponse<GetListEducationPathListItemDto>>().ReverseMap();
    }
}
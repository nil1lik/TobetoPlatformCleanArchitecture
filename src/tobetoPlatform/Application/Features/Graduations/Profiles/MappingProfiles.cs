using Application.Features.Graduations.Commands.Create;
using Application.Features.Graduations.Commands.Delete;
using Application.Features.Graduations.Commands.Update;
using Application.Features.Graduations.Queries.GetById;
using Application.Features.Graduations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Graduations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Graduation, CreateGraduationCommand>().ReverseMap();
        CreateMap<Graduation, CreatedGraduationResponse>().ReverseMap();
        CreateMap<Graduation, UpdateGraduationCommand>().ReverseMap();
        CreateMap<Graduation, UpdatedGraduationResponse>().ReverseMap();
        CreateMap<Graduation, DeleteGraduationCommand>().ReverseMap();
        CreateMap<Graduation, DeletedGraduationResponse>().ReverseMap();
        CreateMap<Graduation, GetByIdGraduationResponse>().ReverseMap();
        CreateMap<Graduation, GetListGraduationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Graduation>, GetListResponse<GetListGraduationListItemDto>>().ReverseMap();
    }
}
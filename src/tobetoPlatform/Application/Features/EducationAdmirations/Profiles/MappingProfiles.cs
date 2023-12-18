using Application.Features.EducationAdmirations.Commands.Create;
using Application.Features.EducationAdmirations.Commands.Delete;
using Application.Features.EducationAdmirations.Commands.Update;
using Application.Features.EducationAdmirations.Queries.GetById;
using Application.Features.EducationAdmirations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EducationAdmirations.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationAdmiration, CreateEducationAdmirationCommand>().ReverseMap();
        CreateMap<EducationAdmiration, CreatedEducationAdmirationResponse>().ReverseMap();
        CreateMap<EducationAdmiration, UpdateEducationAdmirationCommand>().ReverseMap();
        CreateMap<EducationAdmiration, UpdatedEducationAdmirationResponse>().ReverseMap();
        CreateMap<EducationAdmiration, DeleteEducationAdmirationCommand>().ReverseMap();
        CreateMap<EducationAdmiration, DeletedEducationAdmirationResponse>().ReverseMap();
        CreateMap<EducationAdmiration, GetByIdEducationAdmirationResponse>().ReverseMap();
        CreateMap<EducationAdmiration, GetListEducationAdmirationListItemDto>().ReverseMap();
        CreateMap<IPaginate<EducationAdmiration>, GetListResponse<GetListEducationAdmirationListItemDto>>().ReverseMap();
    }
}
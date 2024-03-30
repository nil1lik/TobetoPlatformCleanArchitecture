using Application.Features.ProfileAdmirations.Commands.Create;
using Application.Features.ProfileAdmirations.Commands.Delete;
using Application.Features.ProfileAdmirations.Commands.Update;
using Application.Features.ProfileAdmirations.Queries.GetById;
using Application.Features.ProfileAdmirations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileAdmirations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileAdmiration, CreateProfileAdmirationCommand>().ReverseMap();
        CreateMap<ProfileAdmiration, CreatedProfileAdmirationResponse>().ReverseMap();
        CreateMap<ProfileAdmiration, UpdateProfileAdmirationCommand>().ReverseMap();
        CreateMap<ProfileAdmiration, UpdatedProfileAdmirationResponse>().ReverseMap();
        CreateMap<ProfileAdmiration, DeleteProfileAdmirationCommand>().ReverseMap();
        CreateMap<ProfileAdmiration, DeletedProfileAdmirationResponse>().ReverseMap();
        CreateMap<ProfileAdmiration, GetByIdProfileAdmirationResponse>().ReverseMap();
        CreateMap<ProfileAdmiration, GetListProfileAdmirationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileAdmiration>, GetListResponse<GetListProfileAdmirationListItemDto>>().ReverseMap();
    }
}
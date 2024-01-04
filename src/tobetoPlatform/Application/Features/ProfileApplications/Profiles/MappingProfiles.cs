using Application.Features.ProfileApplications.Commands.Create;
using Application.Features.ProfileApplications.Commands.Delete;
using Application.Features.ProfileApplications.Commands.Update;
using Application.Features.ProfileApplications.Queries.GetById;
using Application.Features.ProfileApplications.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileApplications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileApplication, CreateProfileApplicationCommand>().ReverseMap();
        CreateMap<ProfileApplication, CreatedProfileApplicationResponse>().ReverseMap();
        CreateMap<ProfileApplication, UpdateProfileApplicationCommand>().ReverseMap();
        CreateMap<ProfileApplication, UpdatedProfileApplicationResponse>().ReverseMap();
        CreateMap<ProfileApplication, DeleteProfileApplicationCommand>().ReverseMap();
        CreateMap<ProfileApplication, DeletedProfileApplicationResponse>().ReverseMap();
        CreateMap<ProfileApplication, GetByIdProfileApplicationResponse>().ReverseMap();
        CreateMap<ProfileApplication, GetListProfileApplicationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileApplication>, GetListResponse<GetListProfileApplicationListItemDto>>().ReverseMap();
    }
}
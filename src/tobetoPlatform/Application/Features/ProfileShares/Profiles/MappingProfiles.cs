using Application.Features.ProfileShares.Commands.Create;
using Application.Features.ProfileShares.Commands.Delete;
using Application.Features.ProfileShares.Commands.Update;
using Application.Features.ProfileShares.Queries.GetById;
using Application.Features.ProfileShares.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileShares.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileShare, CreateProfileShareCommand>().ReverseMap();
        CreateMap<ProfileShare, CreatedProfileShareResponse>().ReverseMap();
        CreateMap<ProfileShare, UpdateProfileShareCommand>().ReverseMap();
        CreateMap<ProfileShare, UpdatedProfileShareResponse>().ReverseMap();
        CreateMap<ProfileShare, DeleteProfileShareCommand>().ReverseMap();
        CreateMap<ProfileShare, DeletedProfileShareResponse>().ReverseMap();
        CreateMap<ProfileShare, GetByIdProfileShareResponse>().ReverseMap();
        CreateMap<ProfileShare, GetListProfileShareListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileShare>, GetListResponse<GetListProfileShareListItemDto>>().ReverseMap();
    }
}
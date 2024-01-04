using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Delete;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetById;
using Application.Features.UserProfiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserProfiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, CreatedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, UpdatedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, DeletedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, GetByIdUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, GetListUserProfileListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserProfile>, GetListResponse<GetListUserProfileListItemDto>>().ReverseMap();
    }
}
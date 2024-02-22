using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Delete;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetById;
using Application.Features.UserProfiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.UserProfiles.Queries.GetUserDetail;
using Application.Features.UserProfiles.Queries.GetByUserId;

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
        CreateMap<UserProfile, GetUserDetailDto>().
            ForMember(up=>up.FirstName,opt=>opt.MapFrom(up=>up.User.FirstName)).
            ForMember(up=>up.LastName, opt=>opt.MapFrom(up=>up.User.LastName)).
            ForMember(up=>up.Email, opt=>opt.MapFrom(up=>up.User.Email)).ReverseMap();
        CreateMap<UserProfile, GetListUserProfileListItemDto>().
            ForMember(up => up.FirstName, opt => opt.MapFrom(up => up.User.FirstName)).
            ForMember(up => up.LastName, opt => opt.MapFrom(up => up.User.LastName)).
            ForMember(up => up.Email, opt => opt.MapFrom(up => up.User.Email)).ReverseMap();
        CreateMap<IPaginate<UserProfile>, GetListResponse<GetListUserProfileListItemDto>>().ReverseMap();

        CreateMap<UserProfile, GetByUserIdUserProfileResponse>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ReverseMap();
    }
}
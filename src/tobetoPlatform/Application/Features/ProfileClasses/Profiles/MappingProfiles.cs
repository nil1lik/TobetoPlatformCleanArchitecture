using Application.Features.ProfileClasses.Commands.Create;
using Application.Features.ProfileClasses.Commands.Delete;
using Application.Features.ProfileClasses.Commands.Update;
using Application.Features.ProfileClasses.Queries.GetById;
using Application.Features.ProfileClasses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileClass, CreateProfileClassCommand>().ReverseMap();
        CreateMap<ProfileClass, CreatedProfileClassResponse>().ReverseMap();
        CreateMap<ProfileClass, UpdateProfileClassCommand>().ReverseMap();
        CreateMap<ProfileClass, UpdatedProfileClassResponse>().ReverseMap();
        CreateMap<ProfileClass, DeleteProfileClassCommand>().ReverseMap();
        CreateMap<ProfileClass, DeletedProfileClassResponse>().ReverseMap();
        CreateMap<ProfileClass, GetByIdProfileClassResponse>().ReverseMap();
        CreateMap<ProfileClass, GetListProfileClassListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileClass>, GetListResponse<GetListProfileClassListItemDto>>().ReverseMap();
    }
}
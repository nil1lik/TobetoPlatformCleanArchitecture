using Application.Features.ProfileApplicationForms.Commands.Create;
using Application.Features.ProfileApplicationForms.Commands.Delete;
using Application.Features.ProfileApplicationForms.Commands.Update;
using Application.Features.ProfileApplicationForms.Queries.GetById;
using Application.Features.ProfileApplicationForms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileApplicationForms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileApplicationForm, CreateProfileApplicationFormCommand>().ReverseMap();
        CreateMap<ProfileApplicationForm, CreatedProfileApplicationFormResponse>().ReverseMap();
        CreateMap<ProfileApplicationForm, UpdateProfileApplicationFormCommand>().ReverseMap();
        CreateMap<ProfileApplicationForm, UpdatedProfileApplicationFormResponse>().ReverseMap();
        CreateMap<ProfileApplicationForm, DeleteProfileApplicationFormCommand>().ReverseMap();
        CreateMap<ProfileApplicationForm, DeletedProfileApplicationFormResponse>().ReverseMap();
        CreateMap<ProfileApplicationForm, GetByIdProfileApplicationFormResponse>().ReverseMap();
        CreateMap<ProfileApplicationForm, GetListProfileApplicationFormListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileApplicationForm>, GetListResponse<GetListProfileApplicationFormListItemDto>>().ReverseMap();
    }
}
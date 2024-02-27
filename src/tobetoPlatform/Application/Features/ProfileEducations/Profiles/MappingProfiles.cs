using Application.Features.ProfileEducations.Commands.Create;
using Application.Features.ProfileEducations.Commands.Delete;
using Application.Features.ProfileEducations.Commands.Update;
using Application.Features.ProfileEducations.Queries.GetById;
using Application.Features.ProfileEducations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileEducations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileEducation, CreateProfileEducationCommand>().ReverseMap();
        CreateMap<ProfileEducation, CreatedProfileEducationResponse>().ReverseMap();
        CreateMap<ProfileEducation, UpdateProfileEducationCommand>().ReverseMap();
        CreateMap<ProfileEducation, UpdatedProfileEducationResponse>().ReverseMap();
        CreateMap<ProfileEducation, DeleteProfileEducationCommand>().ReverseMap();
        CreateMap<ProfileEducation, DeletedProfileEducationResponse>().ReverseMap();
        CreateMap<ProfileEducation, GetByIdProfileEducationResponse>().ReverseMap();
        CreateMap<ProfileEducation, GetListProfileEducationListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileEducation>, GetListResponse<GetListProfileEducationListItemDto>>().ReverseMap();
    }
}
using Application.Features.ProfileApplicationSteps.Commands.Create;
using Application.Features.ProfileApplicationSteps.Commands.Delete;
using Application.Features.ProfileApplicationSteps.Commands.Update;
using Application.Features.ProfileApplicationSteps.Queries.GetById;
using Application.Features.ProfileApplicationSteps.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileApplicationSteps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileApplicationStep, CreateProfileApplicationStepCommand>().ReverseMap();
        CreateMap<ProfileApplicationStep, CreatedProfileApplicationStepResponse>().ReverseMap();
        CreateMap<ProfileApplicationStep, UpdateProfileApplicationStepCommand>().ReverseMap();
        CreateMap<ProfileApplicationStep, UpdatedProfileApplicationStepResponse>().ReverseMap();
        CreateMap<ProfileApplicationStep, DeleteProfileApplicationStepCommand>().ReverseMap();
        CreateMap<ProfileApplicationStep, DeletedProfileApplicationStepResponse>().ReverseMap();
        CreateMap<ProfileApplicationStep, GetByIdProfileApplicationStepResponse>().ReverseMap();
        CreateMap<ProfileApplicationStep, GetListProfileApplicationStepListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileApplicationStep>, GetListResponse<GetListProfileApplicationStepListItemDto>>().ReverseMap();
    }
}
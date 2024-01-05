using Application.Features.ApplicationSteps.Commands.Create;
using Application.Features.ApplicationSteps.Commands.Delete;
using Application.Features.ApplicationSteps.Commands.Update;
using Application.Features.ApplicationSteps.Queries.GetById;
using Application.Features.ApplicationSteps.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ApplicationSteps.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationStep, CreateApplicationStepCommand>().ReverseMap();
        CreateMap<ApplicationStep, CreatedApplicationStepResponse>().ReverseMap();
        CreateMap<ApplicationStep, UpdateApplicationStepCommand>().ReverseMap();
        CreateMap<ApplicationStep, UpdatedApplicationStepResponse>().ReverseMap();
        CreateMap<ApplicationStep, DeleteApplicationStepCommand>().ReverseMap();
        CreateMap<ApplicationStep, DeletedApplicationStepResponse>().ReverseMap();
        CreateMap<ApplicationStep, GetByIdApplicationStepResponse>().ReverseMap();
        CreateMap<ApplicationStep, GetListApplicationStepListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationStep>, GetListResponse<GetListApplicationStepListItemDto>>().ReverseMap();
    }
}
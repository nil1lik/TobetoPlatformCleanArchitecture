using Application.Features.ApplicationForms.Commands.Create;
using Application.Features.ApplicationForms.Commands.Delete;
using Application.Features.ApplicationForms.Commands.Update;
using Application.Features.ApplicationForms.Queries.GetById;
using Application.Features.ApplicationForms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ApplicationForms.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationForm, CreateApplicationFormCommand>().ReverseMap();
        CreateMap<ApplicationForm, CreatedApplicationFormResponse>().ReverseMap();
        CreateMap<ApplicationForm, UpdateApplicationFormCommand>().ReverseMap();
        CreateMap<ApplicationForm, UpdatedApplicationFormResponse>().ReverseMap();
        CreateMap<ApplicationForm, DeleteApplicationFormCommand>().ReverseMap();
        CreateMap<ApplicationForm, DeletedApplicationFormResponse>().ReverseMap();
        CreateMap<ApplicationForm, GetByIdApplicationFormResponse>().ReverseMap();
        CreateMap<ApplicationForm, GetListApplicationFormListItemDto>().ReverseMap();
        CreateMap<IPaginate<ApplicationForm>, GetListResponse<GetListApplicationFormListItemDto>>().ReverseMap();
    }
}
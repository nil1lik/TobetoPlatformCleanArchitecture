using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Commands.Delete;
using Application.Features.Companies.Commands.Update;
using Application.Features.Companies.Queries.GetById;
using Application.Features.Companies.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Companies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<Company, CreatedCompanyResponse>().ReverseMap();
        CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
        CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();
        CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
        CreateMap<Company, DeletedCompanyResponse>().ReverseMap();
        CreateMap<Company, GetByIdCompanyResponse>().ReverseMap();
        CreateMap<Company, GetListCompanyListItemDto>().ReverseMap();
        CreateMap<IPaginate<Company>, GetListResponse<GetListCompanyListItemDto>>().ReverseMap();
    }
}
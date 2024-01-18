using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Cities.Queries.GetDistrictById;
using Application.Features.Cities.Queries.GetDistrictList;

namespace Application.Features.Cities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CreateCityCommand>().ReverseMap();
        CreateMap<City, CreatedCityResponse>().ReverseMap();
        CreateMap<City, UpdateCityCommand>().ReverseMap();
        CreateMap<City, UpdatedCityResponse>().ReverseMap();
        CreateMap<City, DeleteCityCommand>().ReverseMap();
        CreateMap<City, DeletedCityResponse>().ReverseMap();
        CreateMap<City, GetByIdCityResponse>().ReverseMap();
        CreateMap<City, GetDistrictByIdCityResponse>()
            .ForMember(d=>d.Districts,opt=>opt.MapFrom(d=>d.Districts.Select(d=>d.Name).ToList()))
            .ReverseMap();
        CreateMap<City, GetListCityListItemDto>().ReverseMap();
        CreateMap<City, GetDistrictListCityListItemDto>()
            .ForMember(d => d.District, opt => opt.MapFrom(d => d.Districts.Select(d => d.Name).ToList()))
            .ReverseMap();
        CreateMap<IPaginate<City>, GetListResponse<GetListCityListItemDto>>().ReverseMap();
        CreateMap<IPaginate<City>, GetListResponse<GetDistrictListCityListItemDto>>().ReverseMap();
    }
}
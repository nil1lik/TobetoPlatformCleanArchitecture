using Application.Features.CatalogPaths.Commands.Create;
using Application.Features.CatalogPaths.Commands.Delete;
using Application.Features.CatalogPaths.Commands.Update;
using Application.Features.CatalogPaths.Queries.GetById;
using Application.Features.CatalogPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.CatalogPaths.Queries.GetCatalogById;

namespace Application.Features.CatalogPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CatalogPath, CreateCatalogPathCommand>().ReverseMap();
        CreateMap<CatalogPath, CreatedCatalogPathResponse>().ReverseMap();
        CreateMap<CatalogPath, UpdateCatalogPathCommand>().ReverseMap();
        CreateMap<CatalogPath, UpdatedCatalogPathResponse>().ReverseMap();
        CreateMap<CatalogPath, DeleteCatalogPathCommand>().ReverseMap();
        CreateMap<CatalogPath, DeletedCatalogPathResponse>().ReverseMap();
        CreateMap<CatalogPath, GetByIdCatalogPathResponse>().ReverseMap();
        CreateMap<CatalogPath, GetCatalogByIdResponse>()
            .ForMember(x=>x.InstructorName,opt=>opt.MapFrom(x=>x.Instructor.FirstName))
            .ForMember(x=>x.InstructorSurname,opt=>opt.MapFrom(x=>x.Instructor.LastName))
            .ReverseMap();
        CreateMap<CatalogPath, GetListCatalogPathListItemDto>().ReverseMap();
        CreateMap<IPaginate<CatalogPath>, GetListResponse<GetListCatalogPathListItemDto>>().ReverseMap();
        CreateMap<IPaginate<CatalogPath>, GetListResponse<GetCatalogByIdResponse>>().ReverseMap();
    }
}
using Application.Features.Classes.Commands.Create;
using Application.Features.Classes.Commands.Delete;
using Application.Features.Classes.Commands.Update;
using Application.Features.Classes.Queries.GetById;
using Application.Features.Classes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Classes.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<Class, CreateClassCommand>().ReverseMap();
        CreateMap<Class, CreatedClassResponse>().ReverseMap();
        CreateMap<Class, UpdateClassCommand>().ReverseMap();
        CreateMap<Class, UpdatedClassResponse>().ReverseMap();
        CreateMap<Class, DeleteClassCommand>().ReverseMap();
        CreateMap<Class, DeletedClassResponse>().ReverseMap();
        CreateMap<Class, GetByIdClassResponse>().ReverseMap();
        CreateMap<Class, GetListClassListItemDto>().ReverseMap();
        CreateMap<IPaginate<Class>, GetListResponse<GetListClassListItemDto>>().ReverseMap();
    }
}
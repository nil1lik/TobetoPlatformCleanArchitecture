using Application.Features.EducationAbouts.Commands.Create;
using Application.Features.EducationAbouts.Commands.Delete;
using Application.Features.EducationAbouts.Commands.Update;
using Application.Features.EducationAbouts.Queries.GetById;
using Application.Features.EducationAbouts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EducationAbouts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationAbout, CreateEducationAboutCommand>().ReverseMap();
        CreateMap<EducationAbout, CreatedEducationAboutResponse>().ReverseMap();
        CreateMap<EducationAbout, UpdateEducationAboutCommand>().ReverseMap();
        CreateMap<EducationAbout, UpdatedEducationAboutResponse>().ReverseMap();
        CreateMap<EducationAbout, DeleteEducationAboutCommand>().ReverseMap();
        CreateMap<EducationAbout, DeletedEducationAboutResponse>().ReverseMap();
        CreateMap<EducationAbout, GetByIdEducationAboutResponse>().ReverseMap();
        CreateMap<EducationAbout, GetListEducationAboutListItemDto>().ReverseMap();
        CreateMap<IPaginate<EducationAbout>, GetListResponse<GetListEducationAboutListItemDto>>().ReverseMap();
    }
}
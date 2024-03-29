using Application.Features.EducationPaths.Commands.Create;
using Application.Features.EducationPaths.Commands.Delete;
using Application.Features.EducationPaths.Commands.Update;
using Application.Features.EducationPaths.Queries.GetById;
using Application.Features.EducationPaths.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.EducationPaths.Queries.GetEducationPathDetailById;
using Application.Features.EducationPaths.Queries.GetCoursesByEducationId;

namespace Application.Features.EducationPaths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EducationPath, CreateEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, CreatedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, UpdateEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, UpdatedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, DeleteEducationPathCommand>().ReverseMap();
        CreateMap<EducationPath, DeletedEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, GetByIdEducationPathResponse>().ReverseMap();
        CreateMap<EducationPath, GetEducationPathDetailByIdDto>().
            ForMember(x => x.IsLiked, opt => opt.MapFrom(x => x.EducationAdmiration.IsLiked)).
            ForMember(x => x.IsFavourited, opt => opt.MapFrom(x => x.EducationAdmiration.IsFavourited)).
            ForMember(x => x.CompletionRate, opt => opt.MapFrom(x => x.EducationAdmiration.CompletionRate)).
            ForMember(x => x.EducationPoint, opt => opt.MapFrom(x => x.EducationAdmiration.EducationPoint)).
            ForMember(x => x.EducationAboutId, opt => opt.MapFrom(x => x.EducationAbout.Id)).
            ReverseMap();
        CreateMap<EducationPath, GetCoursesByEducationIdDto>().
            ForMember(x => x.Courses, opt => opt.MapFrom(x => x.Courses.Select(x => x.Name).ToList()))
            .ReverseMap();
        CreateMap<EducationPath, GetListEducationPathListItemDto>().
            ForMember(x => x.StartDate, opt => opt.MapFrom(x => x.EducationAbout.StartDate))
            .ReverseMap();
        CreateMap<IPaginate<EducationPath>, GetListResponse<GetListEducationPathListItemDto>>().ReverseMap();
    }
} 
using Application.Features.ProfileGraduations.Commands.Create;
using Application.Features.ProfileGraduations.Commands.Delete;
using Application.Features.ProfileGraduations.Commands.Update;
using Application.Features.ProfileGraduations.Queries.GetById;
using Application.Features.ProfileGraduations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.ProfileGraduations.Queries.GetAllGraduationByUserId;

namespace Application.Features.ProfileGraduations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileGraduation, CreateProfileGraduationCommand>().ReverseMap();
        CreateMap<ProfileGraduation, CreatedProfileGraduationResponse>().ReverseMap();
        CreateMap<ProfileGraduation, UpdateProfileGraduationCommand>().ReverseMap();
        CreateMap<ProfileGraduation, UpdatedProfileGraduationResponse>().ReverseMap();
        CreateMap<ProfileGraduation, DeleteProfileGraduationCommand>().ReverseMap();
        CreateMap<ProfileGraduation, DeletedProfileGraduationResponse>().ReverseMap();
        CreateMap<ProfileGraduation, GetByIdProfileGraduationResponse>().ReverseMap();
        CreateMap<ProfileGraduation, GetListProfileGraduationListItemDto>().ReverseMap();
        CreateMap<ProfileGraduation, GetListGraduationItemResponse>()
            .ForMember(x=>x.Degree, opt=>opt.MapFrom(x=>x.Graduation.Degree))
            .ForMember(x=>x.UniversityName, opt=>opt.MapFrom(x=>x.Graduation.UniversityName))
            .ForMember(x=>x.Department, opt=>opt.MapFrom(x=>x.Graduation.Department))
            .ForMember(x=>x.StartDate, opt=>opt.MapFrom(x=>x.Graduation.StartDate))
            .ForMember(x=>x.EndDate, opt=>opt.MapFrom(x=>x.Graduation.EndDate))
            .ReverseMap();

        CreateMap<IPaginate<ProfileGraduation>, GetListResponse<GetListProfileGraduationListItemDto>>().ReverseMap();
        CreateMap<IPaginate<ProfileGraduation>, GetListResponse<GetListGraduationByUserIdQuery>>().ReverseMap();
    }
}
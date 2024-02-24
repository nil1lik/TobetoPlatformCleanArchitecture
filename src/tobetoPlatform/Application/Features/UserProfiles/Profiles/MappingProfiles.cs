using Application.Features.UserProfiles.Commands.Create;
using Application.Features.UserProfiles.Commands.Delete;
using Application.Features.UserProfiles.Commands.Update;
using Application.Features.UserProfiles.Queries.GetById;
using Application.Features.UserProfiles.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.UserProfiles.Queries.GetUserDetail;
using Application.Features.UserProfiles.Queries.GetByUserId;
using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.Cities.Queries.GetDistrictList;
using Application.Features.UserProfiles.Queries.GetAllLanguageByUserId;
using Application.Features.UserProfiles.Queries.GetAllGraduationByUserId;
using Application.Features.UserProfiles.Queries.GetExperienceByUserId;

namespace Application.Features.UserProfiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, CreatedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, UpdatedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
        CreateMap<UserProfile, DeletedUserProfileResponse>().ReverseMap();
        CreateMap<UserProfile, GetUserDetailDto>().
            ForMember(up => up.FirstName, opt => opt.MapFrom(up => up.User.FirstName)).
            ForMember(up => up.LastName, opt => opt.MapFrom(up => up.User.LastName)).
            ForMember(up => up.Email, opt => opt.MapFrom(up => up.User.Email)).
            ForMember(up => up.CityName, opt => opt.MapFrom(up => up.City.Name)).
            ForMember(up => up.CityId, opt => opt.MapFrom(up => up.City.Id)).
            ForMember(up => up.DistrictName, opt => opt.MapFrom(up => up.District.Name)).
            ForMember(up => up.DistrictId, opt => opt.MapFrom(up => up.District.Id)).
            ForMember(up => up.UserProfileId, opt => opt.MapFrom(up=> up.Id)).
            ReverseMap();
        CreateMap<UserProfile, GetListUserProfileListItemDto>().
            ForMember(up => up.FirstName, opt => opt.MapFrom(up => up.User.FirstName)).
            ForMember(up => up.LastName, opt => opt.MapFrom(up => up.User.LastName)).
            ForMember(up => up.Email, opt => opt.MapFrom(up => up.User.Email)).ReverseMap();
        CreateMap<IPaginate<UserProfile>, GetListResponse<GetListUserProfileListItemDto>>().ReverseMap();

        CreateMap<UserProfile, GetByUserIdUserProfileResponse>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ReverseMap();
        CreateMap<UserProfile, GetListSkillsByUserIdResponse>()
         .ForMember(dest => dest.SkillDtoItems, opt => opt.MapFrom(src =>
        src.ProfileSkills.Select(profileSkill => new SkillDto
        {
            SkillId = profileSkill.Skill.Id,
            SkillName = profileSkill.Skill.Name
        }).ToList()))

         .ForMember(x => x.UserProfileId, opt => opt.MapFrom(x => x.UserId))
          .ReverseMap();

        CreateMap<UserProfile, GetListGraduationByUserIdResponse>()
            .ForMember(x => x.UserProfileId, opt => opt.MapFrom(x => x.UserId))
            .ForMember(x => x.GraduationsDtoItems, opt => opt.MapFrom(x => x.Graduations.Select(graduation => new GraduationDto
            {
                Degree = graduation.Degree,
                Department = graduation.Department,
                Id = graduation.Id,
                StartDate = graduation.StartDate,
                EndDate = graduation.EndDate,
                UniversityName = graduation.UniversityName,
                GraduationDate = graduation.GraduationDate

            })))
            .ReverseMap();


        CreateMap<UserProfile, GetListExperienceByUserIdResponse>()
         .ForMember(x => x.UserProfileId, opt => opt.MapFrom(x => x.UserId))
         .ForMember(dest => dest.ExperienceDtoItems, opt => opt.MapFrom(src =>
        src.Experiences.Select(experiences => new ExperienceDto
        {
            Id = experiences.Id,
            OrganizationName = experiences.OrganizationName,
            Description = experiences.Description,
            EndDate = experiences.EndDate,
            Position = experiences.Position,
            Sector = experiences.Sector,
            StartDate = experiences.StartDate,
            CityName = experiences.City.Name

        }).ToList()))
          .ReverseMap();
        CreateMap<UserProfile, GetAllLanguagesByUserIdResponse>()
         .ForMember(x => x.UserProfileId, opt => opt.MapFrom(x => x.UserId))
         .ForMember(la => la.LanguageDtoItems, opt => opt.MapFrom(la => la.ProfileLanguages.Select(x => new LanguageDtoItems
         {
             LanguageId = x.Language.Id,
             LanguageName = x.Language.Name,
             LanguageLevelId = x.LanguageLevel.Id,
             LanguageLevelName = x.LanguageLevel.Name,
         }).ToList())).ReverseMap();
    }
}
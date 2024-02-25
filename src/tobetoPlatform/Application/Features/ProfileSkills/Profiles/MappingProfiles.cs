using Application.Features.ProfileSkills.Commands.Create;
using Application.Features.ProfileSkills.Commands.Delete;
using Application.Features.ProfileSkills.Commands.Update;
using Application.Features.ProfileSkills.Queries.GetById;
using Application.Features.ProfileSkills.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Cities.Queries.GetDistrictList;
using Application.Features.UserProfiles.Queries.GetAllSkillByUserId;
using Application.Features.ProfileSkills.Commands.Delete.DeleteSkillByUserId;

namespace Application.Features.ProfileSkills.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileSkill, CreateProfileSkillCommand>().ReverseMap();
        CreateMap<ProfileSkill, CreatedProfileSkillResponse>().ReverseMap();
        CreateMap<ProfileSkill, UpdateProfileSkillCommand>().ReverseMap();
        CreateMap<ProfileSkill, UpdatedProfileSkillResponse>().ReverseMap();
        CreateMap<ProfileSkill, DeleteProfileSkillCommand>().ReverseMap();
        CreateMap<ProfileSkill, DeletedProfileSkillResponse>().ReverseMap();
        CreateMap<ProfileSkill, DeleteSkillbyUserIdCommand>().ReverseMap();
        CreateMap<ProfileSkill, DeleteSkillByUserIdResponse>().ReverseMap();
        CreateMap<ProfileSkill, GetByIdProfileSkillResponse>().ReverseMap();
        CreateMap<ProfileSkill, GetListProfileSkillListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileSkill>, GetListResponse<GetListProfileSkillListItemDto>>().ReverseMap();
        CreateMap<IPaginate<ProfileSkill>, GetListResponse<GetAllSkillsByUserIdQuery>>().ReverseMap();
    }
}
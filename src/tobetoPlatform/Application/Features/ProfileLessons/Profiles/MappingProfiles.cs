using Application.Features.ProfileLessons.Commands.Create;
using Application.Features.ProfileLessons.Commands.Delete;
using Application.Features.ProfileLessons.Commands.Update;
using Application.Features.ProfileLessons.Queries.GetById;
using Application.Features.ProfileLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ProfileLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProfileLesson, CreateProfileLessonCommand>().ReverseMap();
        CreateMap<ProfileLesson, CreatedProfileLessonResponse>().ReverseMap();
        CreateMap<ProfileLesson, UpdateProfileLessonCommand>().ReverseMap();
        CreateMap<ProfileLesson, UpdatedProfileLessonResponse>().ReverseMap();
        CreateMap<ProfileLesson, DeleteProfileLessonCommand>().ReverseMap();
        CreateMap<ProfileLesson, DeletedProfileLessonResponse>().ReverseMap();
        CreateMap<ProfileLesson, GetByIdProfileLessonResponse>().ReverseMap();
        CreateMap<ProfileLesson, GetListProfileLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<ProfileLesson>, GetListResponse<GetListProfileLessonListItemDto>>().ReverseMap();
    }
}
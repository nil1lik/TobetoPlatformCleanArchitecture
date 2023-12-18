using Application.Features.LessonVideoDetails.Commands.Create;
using Application.Features.LessonVideoDetails.Commands.Delete;
using Application.Features.LessonVideoDetails.Commands.Update;
using Application.Features.LessonVideoDetails.Queries.GetById;
using Application.Features.LessonVideoDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LessonVideoDetails.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonVideoDetail, CreateLessonVideoDetailCommand>().ReverseMap();
        CreateMap<LessonVideoDetail, CreatedLessonVideoDetailResponse>().ReverseMap();
        CreateMap<LessonVideoDetail, UpdateLessonVideoDetailCommand>().ReverseMap();
        CreateMap<LessonVideoDetail, UpdatedLessonVideoDetailResponse>().ReverseMap();
        CreateMap<LessonVideoDetail, DeleteLessonVideoDetailCommand>().ReverseMap();
        CreateMap<LessonVideoDetail, DeletedLessonVideoDetailResponse>().ReverseMap();
        CreateMap<LessonVideoDetail, GetByIdLessonVideoDetailResponse>().ReverseMap();
        CreateMap<LessonVideoDetail, GetListLessonVideoDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonVideoDetail>, GetListResponse<GetListLessonVideoDetailListItemDto>>().ReverseMap();
    }
}
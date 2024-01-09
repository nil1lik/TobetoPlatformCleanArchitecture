using Application.Features.SyncLessons.Commands.Create;
using Application.Features.SyncLessons.Commands.Delete;
using Application.Features.SyncLessons.Commands.Update;
using Application.Features.SyncLessons.Queries.GetById;
using Application.Features.SyncLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SyncLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SyncLesson, CreateSyncLessonCommand>().ReverseMap();
        CreateMap<SyncLesson, CreatedSyncLessonResponse>().ReverseMap();
        CreateMap<SyncLesson, UpdateSyncLessonCommand>().ReverseMap();
        CreateMap<SyncLesson, UpdatedSyncLessonResponse>().ReverseMap();
        CreateMap<SyncLesson, DeleteSyncLessonCommand>().ReverseMap();
        CreateMap<SyncLesson, DeletedSyncLessonResponse>().ReverseMap();
        CreateMap<SyncLesson, GetByIdSyncLessonResponse>().ReverseMap();
        CreateMap<SyncLesson, GetListSyncLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<SyncLesson>, GetListResponse<GetListSyncLessonListItemDto>>().ReverseMap();
    }
}
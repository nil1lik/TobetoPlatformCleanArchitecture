using Application.Features.AsyncLessons.Commands.Create;
using Application.Features.AsyncLessons.Commands.Delete;
using Application.Features.AsyncLessons.Commands.Update;
using Application.Features.AsyncLessons.Queries.GetById;
using Application.Features.AsyncLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AsyncLessons.Profiles;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<AsyncLesson, CreateAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, CreatedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, UpdateAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, UpdatedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, DeleteAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, DeletedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, GetByIdAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, GetListAsyncLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<AsyncLesson>, GetListResponse<GetListAsyncLessonListItemDto>>().ReverseMap();
    }
}
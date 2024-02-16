using Application.Features.AsyncLessons.Commands.Create;
using Application.Features.AsyncLessons.Commands.Delete;
using Application.Features.AsyncLessons.Commands.Update;
using Application.Features.AsyncLessons.Queries.GetById;
using Application.Features.AsyncLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AsyncLessons.Queries.GetLessonDetailByAsyncLessonId;

namespace Application.Features.AsyncLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AsyncLesson, CreateAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, CreatedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, UpdateAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, UpdatedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, DeleteAsyncLessonCommand>().ReverseMap();
        CreateMap<AsyncLesson, DeletedAsyncLessonResponse>().ReverseMap();
        CreateMap<AsyncLesson, GetByIdAsyncLessonResponse>().
             ForMember(al=>al.LessonTypeName, opt=>opt.MapFrom(al=>al.LessonType.Name))
            .ReverseMap();
        CreateMap<AsyncLesson, GetLessonDetailByAsyncLessonIdResponse>()
            .ForMember(al=>al.LessonTypeName, opt=>opt.MapFrom(al=>al.LessonType.Name))
            .ForMember(al=>al.LanguageName, opt=>opt.MapFrom(al=>al.LessonVideoDetail.VideoLanguage.Name))
            .ForMember(al=>al.CompanyName ,opt=>opt.MapFrom(al=>al.LessonVideoDetail.Company.Name))
            //.ForMember(al => al.SubcategoryName, opt=>opt.MapFrom(al=>al.LessonVideoDetail.VideoDetailCategories.Select(al=>al.VideoDetailSubcategories)))
            //.ForMember(al => al.VideoDetailCategories, opt => opt.MapFrom(al => al.LessonVideoDetail.VideoDetailCategories.Select(c => c.Name).ToList()))
            .ForMember(al => al.VideoDetailCategories, opt => opt.MapFrom(al => al.LessonVideoDetail.LessonVideoDetailVideoDetailCategories))

            .ReverseMap();
        CreateMap<AsyncLesson, GetListAsyncLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<AsyncLesson>, GetListResponse<GetListAsyncLessonListItemDto>>().ReverseMap();
    }
}
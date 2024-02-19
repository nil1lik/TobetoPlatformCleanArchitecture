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
             ForMember(al => al.LessonTypeName, opt => opt.MapFrom(al => al.LessonType.Name))
            .ReverseMap();
        CreateMap<AsyncLesson, GetLessonDetailByAsyncLessonIdResponse>()
            .ForMember(al => al.LessonTypeName, opt => opt.MapFrom(al => al.LessonType.Name))
            .ForMember(al => al.LanguageName, opt => opt.MapFrom(al => al.LessonVideoDetail.VideoLanguage.Name))
            .ForMember(al => al.CompanyName, opt => opt.MapFrom(al => al.LessonVideoDetail.Company.Name))

//.ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src =>
//    (src.LessonVideoDetail != null && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Any()) ?
//    string.Join(", ", src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Where(vdc => vdc.VideoDetailCategory != null)
//Select(s => s.Name)) :
//    null))
             //        .ForMember(dest => dest.VideoDetailCategoryName, opt => opt.MapFrom(src => src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories
             //.Select(c => c.VideoDetailCategory.Name)))
             //.ForMember(dest => dest.VideoDetailCategories, opt => opt.MapFrom(src =>
             //(src.LessonVideoDetail != null && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Any() && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.First().VideoDetailCategory != null) ?
             //src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.First().VideoDetailCategory.Name : null))

             .ForMember(dest => dest.VideoDetailCategoryName, opt => opt.MapFrom(src =>
    (src.LessonVideoDetail != null && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Any()) ?
    string.Join(", ", src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories
                                    .Where(vdc => vdc.VideoDetailCategory != null)
                                    .Select(vdc => vdc.VideoDetailCategory.Name)) :
    null))


            //.ForMember(al => al.VideoDetailCategories, opt => opt.MapFrom(al => al.LessonVideoDetail.LessonVideoDetailVideoDetailCategories)) 

            .ReverseMap();
        CreateMap<AsyncLesson, GetListAsyncLessonListItemDto>().ReverseMap();
        CreateMap<IPaginate<AsyncLesson>, GetListResponse<GetListAsyncLessonListItemDto>>().ReverseMap();
    }
}


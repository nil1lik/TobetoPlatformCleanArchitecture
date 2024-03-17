using Application.Features.SyncLessons.Commands.Create;
using Application.Features.SyncLessons.Commands.Delete;
using Application.Features.SyncLessons.Commands.Update;
using Application.Features.SyncLessons.Queries.GetById;
using Application.Features.SyncLessons.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.SyncLessons.Queries.GetLessonDetailBySyncLessonId;

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
        CreateMap<SyncLesson, GetLessonDetailBySyncLessonIdResponse>()
            .ForMember(sl => sl.Name, opt => opt.MapFrom(src => src.Course.Name))
            .ForMember(al => al.LanguageName, opt => opt.MapFrom(al => al.LessonVideoDetail.VideoLanguage.Name))
            .ForMember(al => al.LessonTypeName, opt => opt.MapFrom(al => al.LessonVideoDetail.AsyncLessons.Select(al=>al.LessonType.Name)))


             .ForMember(dest => dest.VideoDetailCategoryName, opt => opt.MapFrom(src =>
    (src.LessonVideoDetail != null && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Any()) ?
    string.Join(" / ", src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories
                                    .Where(vdc => vdc.VideoDetailCategory != null)
                                    .Select(vdc => vdc.VideoDetailCategory.Name)) :
    null))

             .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src =>
    (src.LessonVideoDetail != null && src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories.Any()) ?
    string.Join(" / ", src.LessonVideoDetail.LessonVideoDetailVideoDetailCategories
                                    .Where(vdc => vdc.VideoDetailCategory != null)
                                    .SelectMany(vdc => vdc.VideoDetailCategory.VideoDetailSubcategories
                                        .Where(vds => vds != null)
                                        .Select(vds => vds.Name))) :
    null))
            .ReverseMap();
        CreateMap<IPaginate<SyncLesson>, GetListResponse<GetListSyncLessonListItemDto>>().ReverseMap();
    }
}
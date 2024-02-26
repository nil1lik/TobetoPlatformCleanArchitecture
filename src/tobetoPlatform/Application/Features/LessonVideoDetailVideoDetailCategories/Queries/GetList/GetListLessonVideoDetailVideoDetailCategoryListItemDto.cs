using Core.Application.Dtos;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetList;

public class GetListLessonVideoDetailVideoDetailCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }
}
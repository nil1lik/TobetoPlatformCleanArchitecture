using Core.Application.Responses;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Queries.GetById;

public class GetByIdLessonVideoDetailVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }
}
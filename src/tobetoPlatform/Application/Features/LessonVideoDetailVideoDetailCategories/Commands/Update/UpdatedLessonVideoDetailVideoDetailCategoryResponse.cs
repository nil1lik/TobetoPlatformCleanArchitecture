using Core.Application.Responses;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Update;

public class UpdatedLessonVideoDetailVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }
}
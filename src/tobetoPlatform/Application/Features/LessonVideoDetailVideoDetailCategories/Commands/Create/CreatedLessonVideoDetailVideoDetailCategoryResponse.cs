using Core.Application.Responses;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Create;

public class CreatedLessonVideoDetailVideoDetailCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoDetailCategoryId { get; set; }
}
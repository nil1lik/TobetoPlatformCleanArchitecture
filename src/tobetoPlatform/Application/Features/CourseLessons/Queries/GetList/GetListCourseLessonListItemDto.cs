using Core.Application.Dtos;

namespace Application.Features.CourseLessons.Queries.GetList;

public class GetListCourseLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AsyncLessonId { get; set; }
}
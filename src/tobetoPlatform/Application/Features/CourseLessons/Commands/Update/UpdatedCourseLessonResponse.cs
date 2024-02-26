using Core.Application.Responses;

namespace Application.Features.CourseLessons.Commands.Update;

public class UpdatedCourseLessonResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AsyncLessonId { get; set; }
}
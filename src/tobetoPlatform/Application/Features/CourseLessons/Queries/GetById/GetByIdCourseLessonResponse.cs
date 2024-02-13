using Core.Application.Responses;

namespace Application.Features.CourseLessons.Queries.GetById;

public class GetByIdCourseLessonResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AsyncLessonId { get; set; }
}
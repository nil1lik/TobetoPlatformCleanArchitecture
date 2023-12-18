using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Update;

public class UpdatedCourseResponse : IResponse
{
    public int Id { get; set; }
    public int EducationPathId { get; set; }
    public int CourseLessonId { get; set; }
    public string Name { get; set; }
}
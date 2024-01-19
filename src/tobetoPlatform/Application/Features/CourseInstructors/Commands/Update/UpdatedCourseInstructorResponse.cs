using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Update;

public class UpdatedCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
}
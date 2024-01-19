using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreatedCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
}
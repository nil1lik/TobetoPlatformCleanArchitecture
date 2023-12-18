using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreatedCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
}
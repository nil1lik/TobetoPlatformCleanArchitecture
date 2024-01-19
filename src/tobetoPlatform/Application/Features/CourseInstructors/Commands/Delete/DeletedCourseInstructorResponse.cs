using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Delete;

public class DeletedCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
}
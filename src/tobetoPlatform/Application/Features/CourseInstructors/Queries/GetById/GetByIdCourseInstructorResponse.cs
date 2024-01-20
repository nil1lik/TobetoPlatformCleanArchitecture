using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Queries.GetById;

public class GetByIdCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
}
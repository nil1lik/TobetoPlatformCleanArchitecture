using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Queries.GetById;

public class GetByIdCourseInstructorResponse : IResponse
{
    public int Id { get; set; }
}
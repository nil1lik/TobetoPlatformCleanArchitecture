using Core.Application.Responses;

namespace Application.Features.Courses.Queries.GetById;

public class GetByIdCourseResponse : IResponse
{
    public int Id { get; set; }
    public int EducationPathId { get; set; }
    public string Name { get; set; }
}
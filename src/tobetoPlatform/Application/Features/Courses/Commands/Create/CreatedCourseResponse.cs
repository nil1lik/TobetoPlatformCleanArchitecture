using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public int Id { get; set; }
    public int EducationPathId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }

}
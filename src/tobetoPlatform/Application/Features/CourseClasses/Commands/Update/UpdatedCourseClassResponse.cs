using Core.Application.Responses;

namespace Application.Features.CourseClasses.Commands.Update;

public class UpdatedCourseClassResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
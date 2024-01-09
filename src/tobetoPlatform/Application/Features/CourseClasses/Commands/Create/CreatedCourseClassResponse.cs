using Core.Application.Responses;

namespace Application.Features.CourseClasses.Commands.Create;

public class CreatedCourseClassResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
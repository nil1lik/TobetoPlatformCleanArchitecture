using Core.Application.Responses;

namespace Application.Features.CourseLessons.Commands.Create;

public class CreatedCourseLessonResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.CourseLessons.Commands.Delete;

public class DeletedCourseLessonResponse : IResponse
{
    public int Id { get; set; }
}
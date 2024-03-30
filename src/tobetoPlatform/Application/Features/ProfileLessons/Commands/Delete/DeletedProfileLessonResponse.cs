using Core.Application.Responses;

namespace Application.Features.ProfileLessons.Commands.Delete;

public class DeletedProfileLessonResponse : IResponse
{
    public int Id { get; set; }
}
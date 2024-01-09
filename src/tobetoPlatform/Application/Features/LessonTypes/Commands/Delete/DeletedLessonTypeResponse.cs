using Core.Application.Responses;

namespace Application.Features.LessonTypes.Commands.Delete;

public class DeletedLessonTypeResponse : IResponse
{
    public int Id { get; set; }
}
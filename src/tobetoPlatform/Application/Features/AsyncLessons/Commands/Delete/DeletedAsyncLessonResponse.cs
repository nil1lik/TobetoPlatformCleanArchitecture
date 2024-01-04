using Core.Application.Responses;

namespace Application.Features.AsyncLessons.Commands.Delete;

public class DeletedAsyncLessonResponse : IResponse
{
    public int Id { get; set; }
}
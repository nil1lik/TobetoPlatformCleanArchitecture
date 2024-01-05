using Core.Application.Responses;

namespace Application.Features.SyncLessons.Commands.Delete;

public class DeletedSyncLessonResponse : IResponse
{
    public int Id { get; set; }
}
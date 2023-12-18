using Core.Application.Responses;

namespace Application.Features.LessonVideoDetails.Commands.Delete;

public class DeletedLessonVideoDetailResponse : IResponse
{
    public int Id { get; set; }
}
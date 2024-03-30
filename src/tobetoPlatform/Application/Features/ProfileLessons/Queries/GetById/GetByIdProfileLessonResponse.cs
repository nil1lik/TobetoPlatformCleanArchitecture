using Core.Application.Responses;

namespace Application.Features.ProfileLessons.Queries.GetById;

public class GetByIdProfileLessonResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }
}
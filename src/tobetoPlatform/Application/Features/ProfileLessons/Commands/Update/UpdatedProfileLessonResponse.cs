using Core.Application.Responses;

namespace Application.Features.ProfileLessons.Commands.Update;

public class UpdatedProfileLessonResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }
}
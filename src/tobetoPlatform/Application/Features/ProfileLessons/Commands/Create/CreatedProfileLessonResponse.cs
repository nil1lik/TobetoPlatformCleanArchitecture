using Core.Application.Responses;

namespace Application.Features.ProfileLessons.Commands.Create;

public class CreatedProfileLessonResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }
}
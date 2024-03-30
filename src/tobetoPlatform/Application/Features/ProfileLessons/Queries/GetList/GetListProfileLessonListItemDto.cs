using Core.Application.Dtos;

namespace Application.Features.ProfileLessons.Queries.GetList;

public class GetListProfileLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int AsyncLessonId { get; set; }
    public bool IsWatched { get; set; }
}
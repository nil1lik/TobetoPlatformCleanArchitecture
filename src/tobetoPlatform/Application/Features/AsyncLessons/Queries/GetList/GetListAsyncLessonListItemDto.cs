using Core.Application.Dtos;

namespace Application.Features.AsyncLessons.Queries.GetList;

public class GetListAsyncLessonListItemDto : IDto
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public int LessonTypeId { get; set; }
    public int CourseClassId { get; set; }
    public string Name { get; set; }
    public TimeSpan Time { get; set; }
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; }
}
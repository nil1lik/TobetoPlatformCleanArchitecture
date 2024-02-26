using Core.Application.Responses;

namespace Application.Features.AsyncLessons.Queries.GetById;

public class GetByIdAsyncLessonResponse : IResponse
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public int LessonTypeId { get; set; }
    public string Name { get; set; }
    public string LessonTypeName { get; set; }
    public TimeSpan Time { get; set; }
    public string VideoUrl { get; set; }
    public bool IsCompleted { get; set; } 
}
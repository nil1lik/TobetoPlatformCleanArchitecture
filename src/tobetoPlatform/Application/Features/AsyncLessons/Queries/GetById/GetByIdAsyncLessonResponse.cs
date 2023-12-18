using Core.Application.Responses;

namespace Application.Features.AsyncLessons.Queries.GetById;

public class GetByIdAsyncLessonResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileEducationId { get; set; }
    public int CourseLessonId { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int VideoCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string VideoUrl { get; set; }
}
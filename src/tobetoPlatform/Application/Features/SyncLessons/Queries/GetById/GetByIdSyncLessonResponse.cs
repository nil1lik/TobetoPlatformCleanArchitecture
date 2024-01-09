using Core.Application.Responses;

namespace Application.Features.SyncLessons.Queries.GetById;

public class GetByIdSyncLessonResponse : IResponse
{
    public int Id { get; set; }
    public int LessonVideoDetailId { get; set; }
    public int CourseId { get; set; }
    public string SyncVideoUrl { get; set; }
    public string SessionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan Time { get; set; }
    public bool IsJoin { get; set; }
    public string LessonSituation { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.Calendars.Commands.Update;

public class UpdatedCalendarResponse : IResponse
{
    public int Id { get; set; }
    public int SyncLessonId { get; set; }
    public int InstructorId { get; set; }
    public int EducationPathId { get; set; }
}
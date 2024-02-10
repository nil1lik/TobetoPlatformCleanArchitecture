using Core.Application.Dtos;

namespace Application.Features.Calendars.Queries.GetList;

public class GetListCalendarListItemDto : IDto
{
    public int Id { get; set; }
    public int SyncLessonId { get; set; }
    public int InstructorId { get; set; }
    public int EducationPathId { get; set; }
}
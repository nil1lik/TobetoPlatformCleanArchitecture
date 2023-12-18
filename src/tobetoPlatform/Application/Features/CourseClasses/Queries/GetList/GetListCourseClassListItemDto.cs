using Core.Application.Dtos;

namespace Application.Features.CourseClasses.Queries.GetList;

public class GetListCourseClassListItemDto : IDto
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}
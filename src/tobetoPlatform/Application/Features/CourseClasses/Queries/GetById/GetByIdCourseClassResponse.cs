using Core.Application.Responses;

namespace Application.Features.CourseClasses.Queries.GetById;

public class GetByIdCourseClassResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }
}
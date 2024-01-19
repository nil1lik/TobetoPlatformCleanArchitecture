using Core.Application.Dtos;

namespace Application.Features.CourseInstructors.Queries.GetList;

public class GetListCourseInstructorListItemDto : IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int InstructorId { get; set; }
}
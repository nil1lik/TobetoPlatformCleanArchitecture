using Core.Application.Dtos;

namespace Application.Features.CourseLessons.Queries.GetList;

public class GetListCourseLessonListItemDto : IDto
{
    public int Id { get; set; }
}
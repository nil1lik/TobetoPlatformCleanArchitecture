using Core.Application.Dtos;

namespace Application.Features.LessonTypes.Queries.GetList;

public class GetListLessonTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.LessonVideoDetails.Queries.GetList;

public class GetListLessonVideoDetailListItemDto : IDto
{
    public int Id { get; set; }
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }
}
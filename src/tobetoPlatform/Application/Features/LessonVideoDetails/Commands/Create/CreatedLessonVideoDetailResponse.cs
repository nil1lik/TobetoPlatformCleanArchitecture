using Core.Application.Responses;

namespace Application.Features.LessonVideoDetails.Commands.Create;

public class CreatedLessonVideoDetailResponse : IResponse
{
    public int Id { get; set; }
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.LessonVideoDetails.Commands.Update;

public class UpdatedLessonVideoDetailResponse : IResponse
{
    public int Id { get; set; }
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }
}
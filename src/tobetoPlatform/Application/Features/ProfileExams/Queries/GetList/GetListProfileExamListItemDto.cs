using Core.Application.Dtos;

namespace Application.Features.ProfileExams.Queries.GetList;

public class GetListProfileExamListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }
}
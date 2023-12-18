using Core.Application.Dtos;

namespace Application.Features.ExamResults.Queries.GetList;

public class GetListExamResultListItemDto : IDto
{
    public int Id { get; set; }
    public int ExamStatusId { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Empty { get; set; }
    public int Point { get; set; }
}
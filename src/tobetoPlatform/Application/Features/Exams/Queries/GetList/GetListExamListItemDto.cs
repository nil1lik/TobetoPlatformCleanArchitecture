using Core.Application.Dtos;

namespace Application.Features.Exams.Queries.GetList;

public class GetListExamListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int ExamPoint { get; set; }
    public DateTime ExamResultCreatedDate { get; set; }
}
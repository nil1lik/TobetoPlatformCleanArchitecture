using Core.Application.Responses;

namespace Application.Features.Exams.Queries.GetById;

public class GetByIdExamResponse : IResponse
{
    public int Id { get; set; }
    public int ExamResultId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
}
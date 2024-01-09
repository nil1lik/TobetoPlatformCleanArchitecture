using Core.Application.Responses;

namespace Application.Features.ExamResults.Queries.GetById;

public class GetByIdExamResultResponse : IResponse
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Empty { get; set; }
    public int Point { get; set; }
}
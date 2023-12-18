using Core.Application.Responses;

namespace Application.Features.ExamResults.Commands.Create;

public class CreatedExamResultResponse : IResponse
{
    public int Id { get; set; }
    public int ExamStatusId { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Empty { get; set; }
    public int Point { get; set; }
}
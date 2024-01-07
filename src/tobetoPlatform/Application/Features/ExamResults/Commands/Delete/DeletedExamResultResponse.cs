using Core.Application.Responses;

namespace Application.Features.ExamResults.Commands.Delete;

public class DeletedExamResultResponse : IResponse
{
    public int Id { get; set; }
}
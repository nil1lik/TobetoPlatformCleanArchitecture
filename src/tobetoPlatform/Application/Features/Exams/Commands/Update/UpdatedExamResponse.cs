using Core.Application.Responses;

namespace Application.Features.Exams.Commands.Update;

public class UpdatedExamResponse : IResponse
{
    public int Id { get; set; }
    public int ExamResultId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int QuestionCount { get; set; }
    public bool IsCompleted { get; set; }
}
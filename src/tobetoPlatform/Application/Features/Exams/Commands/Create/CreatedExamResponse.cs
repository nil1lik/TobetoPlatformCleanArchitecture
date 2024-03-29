using Core.Application.Responses;

namespace Application.Features.Exams.Commands.Create;

public class CreatedExamResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Duration { get; set; }
    public int QuestionCount { get; set; }
    public bool IsCompleted { get; set; }
}
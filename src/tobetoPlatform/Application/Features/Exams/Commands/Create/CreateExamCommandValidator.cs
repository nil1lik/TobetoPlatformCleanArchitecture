using FluentValidation;

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommand>
{
    public CreateExamCommandValidator()
    {
        //RuleFor(c => c.ExamResultId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description);
        RuleFor(c => c.Duration).NotEmpty();
        RuleFor(c => c.QuestionCount).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.ExamResults.Commands.Create;

public class CreateExamResultCommandValidator : AbstractValidator<CreateExamResultCommand>
{
    public CreateExamResultCommandValidator()
    {
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.Correct);
        RuleFor(c => c.Wrong);
        RuleFor(c => c.Empty);
        RuleFor(c => c.Point).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.ExamResults.Commands.Create;

public class CreateExamResultCommandValidator : AbstractValidator<CreateExamResultCommand>
{
    public CreateExamResultCommandValidator()
    {
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.Correct).NotEmpty();
        RuleFor(c => c.Wrong).NotEmpty();
        RuleFor(c => c.Empty).NotEmpty();
        RuleFor(c => c.Point).NotEmpty();
    }
}
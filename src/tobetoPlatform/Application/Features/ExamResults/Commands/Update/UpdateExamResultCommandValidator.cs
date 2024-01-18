using FluentValidation;

namespace Application.Features.ExamResults.Commands.Update;

public class UpdateExamResultCommandValidator : AbstractValidator<UpdateExamResultCommand>
{
    public UpdateExamResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
        RuleFor(c => c.Correct);
        RuleFor(c => c.Wrong);
        RuleFor(c => c.Empty);
        RuleFor(c => c.Point).NotEmpty();
    }
}
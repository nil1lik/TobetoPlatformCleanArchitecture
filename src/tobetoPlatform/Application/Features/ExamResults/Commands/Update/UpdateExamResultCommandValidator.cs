using FluentValidation;

namespace Application.Features.ExamResults.Commands.Update;

public class UpdateExamResultCommandValidator : AbstractValidator<UpdateExamResultCommand>
{
    public UpdateExamResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ExamStatusId).NotEmpty();
        RuleFor(c => c.Correct).NotEmpty();
        RuleFor(c => c.Wrong).NotEmpty();
        RuleFor(c => c.Empty).NotEmpty();
        RuleFor(c => c.Point).NotEmpty();
    }
}
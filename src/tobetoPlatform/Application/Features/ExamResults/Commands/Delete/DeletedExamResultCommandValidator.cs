using FluentValidation;

namespace Application.Features.ExamResults.Commands.Delete;

public class DeleteExamResultCommandValidator : AbstractValidator<DeleteExamResultCommand>
{
    public DeleteExamResultCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
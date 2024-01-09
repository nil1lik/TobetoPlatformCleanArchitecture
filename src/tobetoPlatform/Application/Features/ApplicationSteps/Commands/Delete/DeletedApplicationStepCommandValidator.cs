using FluentValidation;

namespace Application.Features.ApplicationSteps.Commands.Delete;

public class DeleteApplicationStepCommandValidator : AbstractValidator<DeleteApplicationStepCommand>
{
    public DeleteApplicationStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
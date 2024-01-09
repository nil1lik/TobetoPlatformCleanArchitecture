using FluentValidation;

namespace Application.Features.ProfileApplicationSteps.Commands.Delete;

public class DeleteProfileApplicationStepCommandValidator : AbstractValidator<DeleteProfileApplicationStepCommand>
{
    public DeleteProfileApplicationStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.ProfileApplicationSteps.Commands.Create;

public class CreateProfileApplicationStepCommandValidator : AbstractValidator<CreateProfileApplicationStepCommand>
{
    public CreateProfileApplicationStepCommandValidator()
    {
        RuleFor(c => c.ApplicationStepId).NotEmpty();
        RuleFor(c => c.ProfileApplicationId).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
    }
}
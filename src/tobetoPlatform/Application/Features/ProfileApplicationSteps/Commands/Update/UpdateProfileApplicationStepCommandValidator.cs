using FluentValidation;

namespace Application.Features.ProfileApplicationSteps.Commands.Update;

public class UpdateProfileApplicationStepCommandValidator : AbstractValidator<UpdateProfileApplicationStepCommand>
{
    public UpdateProfileApplicationStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicationStepId).NotEmpty();
        RuleFor(c => c.ProfileApplicationId).NotEmpty();
        RuleFor(c => c.IsCompleted).NotEmpty();
    }
}
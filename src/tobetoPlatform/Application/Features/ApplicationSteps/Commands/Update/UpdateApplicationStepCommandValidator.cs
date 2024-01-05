using FluentValidation;

namespace Application.Features.ApplicationSteps.Commands.Update;

public class UpdateApplicationStepCommandValidator : AbstractValidator<UpdateApplicationStepCommand>
{
    public UpdateApplicationStepCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserApplicationId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DocumentUrl).NotEmpty();
        RuleFor(c => c.FormUrl).NotEmpty();
    }
}
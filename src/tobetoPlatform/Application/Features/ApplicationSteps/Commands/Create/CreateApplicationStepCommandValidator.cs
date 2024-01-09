using FluentValidation;

namespace Application.Features.ApplicationSteps.Commands.Create;

public class CreateApplicationStepCommandValidator : AbstractValidator<CreateApplicationStepCommand>
{
    public CreateApplicationStepCommandValidator()
    {
        RuleFor(c => c.UserApplicationId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DocumentUrl).NotEmpty();
        RuleFor(c => c.FormUrl).NotEmpty();
    }
}
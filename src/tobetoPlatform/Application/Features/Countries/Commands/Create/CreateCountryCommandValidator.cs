using FluentValidation;

namespace Application.Features.Countries.Commands.Create;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
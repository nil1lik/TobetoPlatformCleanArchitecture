using FluentValidation;

namespace Application.Features.Companies.Commands.Create;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
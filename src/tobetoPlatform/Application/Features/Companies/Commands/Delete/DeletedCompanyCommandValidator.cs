using FluentValidation;

namespace Application.Features.Companies.Commands.Delete;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
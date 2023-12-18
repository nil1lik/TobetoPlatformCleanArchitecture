using FluentValidation;

namespace Application.Features.LanguageLevels.Commands.Create;

public class CreateLanguageLevelCommandValidator : AbstractValidator<CreateLanguageLevelCommand>
{
    public CreateLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
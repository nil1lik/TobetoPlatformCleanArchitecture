using FluentValidation;

namespace Application.Features.LanguageLevels.Commands.Update;

public class UpdateLanguageLevelCommandValidator : AbstractValidator<UpdateLanguageLevelCommand>
{
    public UpdateLanguageLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.VideoLanguages.Commands.Create;

public class CreateVideoLanguageCommandValidator : AbstractValidator<CreateVideoLanguageCommand>
{
    public CreateVideoLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
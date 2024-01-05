using FluentValidation;

namespace Application.Features.VideoLanguages.Commands.Update;

public class UpdateVideoLanguageCommandValidator : AbstractValidator<UpdateVideoLanguageCommand>
{
    public UpdateVideoLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
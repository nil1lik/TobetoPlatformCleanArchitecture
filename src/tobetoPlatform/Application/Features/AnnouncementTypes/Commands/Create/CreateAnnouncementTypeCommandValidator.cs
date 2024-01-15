using FluentValidation;

namespace Application.Features.AnnouncementTypes.Commands.Create;

public class CreateAnnouncementTypeCommandValidator : AbstractValidator<CreateAnnouncementTypeCommand>
{
    public CreateAnnouncementTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
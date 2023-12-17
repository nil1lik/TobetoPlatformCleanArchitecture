using FluentValidation;

namespace Application.Features.Classes.Commands.Create;

public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
{
    public CreateClassCommandValidator()
    {
        RuleFor(c => c.ProfileAnnouncementId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
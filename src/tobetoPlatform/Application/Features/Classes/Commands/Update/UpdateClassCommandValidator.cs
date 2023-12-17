using FluentValidation;

namespace Application.Features.Classes.Commands.Update;

public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileAnnouncementId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
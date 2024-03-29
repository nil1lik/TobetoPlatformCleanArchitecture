using FluentValidation;

namespace Application.Features.Announcements.Commands.Update;

public class UpdateAnnouncementCommandValidator : AbstractValidator<UpdateAnnouncementCommand>
{
    public UpdateAnnouncementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AnnouncementTypeId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IsRead).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.Calendars.Commands.Delete;

public class DeleteCalendarCommandValidator : AbstractValidator<DeleteCalendarCommand>
{
    public DeleteCalendarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
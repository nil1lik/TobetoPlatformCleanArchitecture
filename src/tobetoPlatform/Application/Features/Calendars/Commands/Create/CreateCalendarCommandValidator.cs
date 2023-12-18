using FluentValidation;

namespace Application.Features.Calendars.Commands.Create;

public class CreateCalendarCommandValidator : AbstractValidator<CreateCalendarCommand>
{
    public CreateCalendarCommandValidator()
    {
        RuleFor(c => c.SyncLessonId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
    }
}
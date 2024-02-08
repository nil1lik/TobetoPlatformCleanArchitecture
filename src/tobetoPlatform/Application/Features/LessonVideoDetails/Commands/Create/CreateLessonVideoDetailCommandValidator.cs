using FluentValidation;

namespace Application.Features.LessonVideoDetails.Commands.Create;

public class CreateLessonVideoDetailCommandValidator : AbstractValidator<CreateLessonVideoDetailCommand>
{
    public CreateLessonVideoDetailCommandValidator()
    {
        RuleFor(c => c.VideoLanguageId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}
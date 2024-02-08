using FluentValidation;

namespace Application.Features.LessonVideoDetails.Commands.Update;

public class UpdateLessonVideoDetailCommandValidator : AbstractValidator<UpdateLessonVideoDetailCommand>
{
    public UpdateLessonVideoDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.VideoLanguageId).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}
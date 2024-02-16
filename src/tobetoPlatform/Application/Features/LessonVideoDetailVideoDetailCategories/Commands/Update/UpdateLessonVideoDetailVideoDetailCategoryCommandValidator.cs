using FluentValidation;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Update;

public class UpdateLessonVideoDetailVideoDetailCategoryCommandValidator : AbstractValidator<UpdateLessonVideoDetailVideoDetailCategoryCommand>
{
    public UpdateLessonVideoDetailVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LessonVideoDetailId).NotEmpty();
        RuleFor(c => c.VideoDetailCategoryId).NotEmpty();
    }
}
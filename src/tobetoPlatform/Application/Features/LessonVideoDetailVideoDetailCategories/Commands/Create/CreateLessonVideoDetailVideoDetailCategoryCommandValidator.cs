using FluentValidation;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Create;

public class CreateLessonVideoDetailVideoDetailCategoryCommandValidator : AbstractValidator<CreateLessonVideoDetailVideoDetailCategoryCommand>
{
    public CreateLessonVideoDetailVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.LessonVideoDetailId).NotEmpty();
        RuleFor(c => c.VideoDetailCategoryId).NotEmpty();
    }
}
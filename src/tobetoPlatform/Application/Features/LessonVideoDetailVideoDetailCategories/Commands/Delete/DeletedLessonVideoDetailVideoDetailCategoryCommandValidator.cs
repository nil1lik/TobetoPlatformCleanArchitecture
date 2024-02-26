using FluentValidation;

namespace Application.Features.LessonVideoDetailVideoDetailCategories.Commands.Delete;

public class DeleteLessonVideoDetailVideoDetailCategoryCommandValidator : AbstractValidator<DeleteLessonVideoDetailVideoDetailCategoryCommand>
{
    public DeleteLessonVideoDetailVideoDetailCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
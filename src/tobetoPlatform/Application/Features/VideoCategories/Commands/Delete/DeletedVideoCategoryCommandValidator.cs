using FluentValidation;

namespace Application.Features.VideoCategories.Commands.Delete;

public class DeleteVideoCategoryCommandValidator : AbstractValidator<DeleteVideoCategoryCommand>
{
    public DeleteVideoCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
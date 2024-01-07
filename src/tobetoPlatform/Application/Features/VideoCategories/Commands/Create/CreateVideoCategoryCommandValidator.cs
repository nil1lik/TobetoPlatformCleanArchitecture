using FluentValidation;

namespace Application.Features.VideoCategories.Commands.Create;

public class CreateVideoCategoryCommandValidator : AbstractValidator<CreateVideoCategoryCommand>
{
    public CreateVideoCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
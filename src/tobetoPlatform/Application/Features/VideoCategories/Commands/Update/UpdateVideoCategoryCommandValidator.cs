using FluentValidation;

namespace Application.Features.VideoCategories.Commands.Update;

public class UpdateVideoCategoryCommandValidator : AbstractValidator<UpdateVideoCategoryCommand>
{
    public UpdateVideoCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}
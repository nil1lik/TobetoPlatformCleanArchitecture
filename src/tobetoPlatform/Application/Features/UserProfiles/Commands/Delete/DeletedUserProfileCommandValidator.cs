using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Delete;

public class DeleteUserProfileCommandValidator : AbstractValidator<DeleteUserProfileCommand>
{
    public DeleteUserProfileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
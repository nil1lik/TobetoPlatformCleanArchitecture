using FluentValidation;

namespace Application.Features.ProfileGraduations.Commands.Update;

public class UpdateProfileGraduationCommandValidator : AbstractValidator<UpdateProfileGraduationCommand>
{
    public UpdateProfileGraduationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GraduationId).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
    }
}
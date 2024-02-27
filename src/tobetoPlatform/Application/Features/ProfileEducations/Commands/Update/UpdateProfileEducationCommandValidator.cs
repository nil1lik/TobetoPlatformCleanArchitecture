using FluentValidation;

namespace Application.Features.ProfileEducations.Commands.Update;

public class UpdateProfileEducationCommandValidator : AbstractValidator<UpdateProfileEducationCommand>
{
    public UpdateProfileEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.EducationPathId).NotEmpty();
    }
}
using FluentValidation;

namespace Application.Features.EducationPaths.Commands.Update;

public class UpdateEducationPathCommandValidator : AbstractValidator<UpdateEducationPathCommand>
{
    public UpdateEducationPathCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProfileEducationId).NotEmpty();
        RuleFor(c => c.EducationAboutId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}
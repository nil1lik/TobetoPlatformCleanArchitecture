using FluentValidation;

namespace Application.Features.Graduations.Commands.Update;

public class UpdateGraduationCommandValidator : AbstractValidator<UpdateGraduationCommand>
{
    public UpdateGraduationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Degree).NotEmpty();
        RuleFor(c => c.UniversityName).NotEmpty();
        RuleFor(c => c.Department).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.GraduationDate).NotEmpty();
    }
}
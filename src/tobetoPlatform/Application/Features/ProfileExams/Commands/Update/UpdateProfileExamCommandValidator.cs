using FluentValidation;

namespace Application.Features.ProfileExams.Commands.Update;

public class UpdateProfileExamCommandValidator : AbstractValidator<UpdateProfileExamCommand>
{
    public UpdateProfileExamCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserProfileId).NotEmpty();
        RuleFor(c => c.ExamId).NotEmpty();
    }
}
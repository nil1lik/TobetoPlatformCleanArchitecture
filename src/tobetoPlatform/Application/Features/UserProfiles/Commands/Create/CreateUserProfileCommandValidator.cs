using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Create;

public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ProfileApplicationId).NotEmpty();
        RuleFor(c => c.ProfileAddressId).NotEmpty();
        RuleFor(c => c.ProfileClassId).NotEmpty();
        RuleFor(c => c.ProfileAnnouncementId).NotEmpty();
        RuleFor(c => c.ProfileGraduationId).NotEmpty();
        RuleFor(c => c.ProfileLanguageId).NotEmpty();
        RuleFor(c => c.ProfileSkillId).NotEmpty();
        RuleFor(c => c.ProfileExperienceId).NotEmpty();
        RuleFor(c => c.ProfileExamId).NotEmpty();
        RuleFor(c => c.ProfileSurveyId).NotEmpty();
        RuleFor(c => c.ProfileEducationId).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}
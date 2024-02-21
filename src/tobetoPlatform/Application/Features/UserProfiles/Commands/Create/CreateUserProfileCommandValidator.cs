using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Create;

public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.NationalIdentity).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.AddressDetail);
        RuleFor(c => c.Description);
    }
}
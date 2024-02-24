using FluentValidation;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.AddressDetail).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}
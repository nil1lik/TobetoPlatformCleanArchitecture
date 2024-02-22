using Core.Application.Responses;

namespace Application.Features.UserProfiles.Commands.Create;

public class CreatedUserProfileResponse : IResponse
{
    public int? Id { get; set; }
    public int? UserId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
}
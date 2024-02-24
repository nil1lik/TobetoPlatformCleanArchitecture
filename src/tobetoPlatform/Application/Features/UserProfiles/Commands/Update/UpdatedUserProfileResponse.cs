using Core.Application.Responses;

namespace Application.Features.UserProfiles.Commands.Update;

public class UpdatedUserProfileResponse : IResponse
{
    public int? UserId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
    public string? Message { get; set; }
}
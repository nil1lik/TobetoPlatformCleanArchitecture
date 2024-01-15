using Core.Application.Responses;

namespace Application.Features.ProfileAddresses.Commands.Update;

public class UpdatedProfileAddressResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string AddressDetail { get; set; }
}
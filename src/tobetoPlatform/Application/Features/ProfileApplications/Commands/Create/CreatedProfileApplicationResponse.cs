using Core.Application.Responses;

namespace Application.Features.ProfileApplications.Commands.Create;

public class CreatedProfileApplicationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int UserApplicationId { get; set; }
}
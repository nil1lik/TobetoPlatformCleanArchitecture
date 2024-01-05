using Core.Application.Responses;

namespace Application.Features.ProfileApplications.Queries.GetById;

public class GetByIdProfileApplicationResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int UserApplicationId { get; set; }
}
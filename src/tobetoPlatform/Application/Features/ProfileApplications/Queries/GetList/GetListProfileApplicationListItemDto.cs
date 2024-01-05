using Core.Application.Dtos;

namespace Application.Features.ProfileApplications.Queries.GetList;

public class GetListProfileApplicationListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int UserApplicationId { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}
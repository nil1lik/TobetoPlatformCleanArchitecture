using Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Queries.GetById;

public class GetByIdSocialMediaAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string MediaUrl { get; set; }
}
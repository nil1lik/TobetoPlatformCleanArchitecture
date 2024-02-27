using Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdatedSocialMediaAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string MediaUrl { get; set; }
}
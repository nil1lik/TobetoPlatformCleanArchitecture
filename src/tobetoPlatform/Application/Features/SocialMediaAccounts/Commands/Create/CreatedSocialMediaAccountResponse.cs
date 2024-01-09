using Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreatedSocialMediaAccountResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }
}
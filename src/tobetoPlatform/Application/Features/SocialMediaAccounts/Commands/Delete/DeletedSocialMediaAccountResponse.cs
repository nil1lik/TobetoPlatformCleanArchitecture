using Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Delete;

public class DeletedSocialMediaAccountResponse : IResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
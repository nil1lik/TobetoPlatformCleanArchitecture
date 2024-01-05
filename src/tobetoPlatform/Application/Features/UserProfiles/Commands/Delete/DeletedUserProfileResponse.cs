using Core.Application.Responses;

namespace Application.Features.UserProfiles.Commands.Delete;

public class DeletedUserProfileResponse : IResponse
{
    public int Id { get; set; }
}
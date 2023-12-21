using Core.Application.Responses;

namespace Application.Features.UserProfiles.Commands.Delete;

public class DeletedUserProfileResponse : IResponse
{
    public Guid Id { get; set; }
}
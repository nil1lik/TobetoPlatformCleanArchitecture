using Core.Application.Responses;

namespace Application.Features.ProfileShares.Commands.Update;

public class UpdatedProfileShareResponse : IResponse
{
    public Guid ProfileUrl { get; set; }
}
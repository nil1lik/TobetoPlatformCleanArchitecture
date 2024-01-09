using Core.Application.Responses;

namespace Application.Features.ProfileShares.Commands.Create;

public class CreatedProfileShareResponse : IResponse
{
    public int Id { get; set; }
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }
}
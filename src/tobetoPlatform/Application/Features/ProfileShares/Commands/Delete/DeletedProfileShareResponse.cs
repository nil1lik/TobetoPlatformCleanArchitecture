using Core.Application.Responses;

namespace Application.Features.ProfileShares.Commands.Delete;

public class DeletedProfileShareResponse : IResponse
{
    public int Id { get; set; }
}
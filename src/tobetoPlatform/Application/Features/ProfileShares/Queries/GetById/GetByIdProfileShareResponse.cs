using Core.Application.Responses;

namespace Application.Features.ProfileShares.Queries.GetById;

public class GetByIdProfileShareResponse : IResponse
{
    public int Id { get; set; }
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }
}
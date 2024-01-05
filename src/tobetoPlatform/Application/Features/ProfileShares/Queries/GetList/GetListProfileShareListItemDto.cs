using Core.Application.Dtos;

namespace Application.Features.ProfileShares.Queries.GetList;

public class GetListProfileShareListItemDto : IDto
{
    public int Id { get; set; }
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }
}
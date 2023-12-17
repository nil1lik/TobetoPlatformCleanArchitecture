using Core.Application.Dtos;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
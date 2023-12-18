using Core.Application.Dtos;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.CatalogPaths.Queries.GetList;

public class GetListCatalogPathListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int InstructorId { get; set; }
    public DateTime AddedDate { get; set; }
}
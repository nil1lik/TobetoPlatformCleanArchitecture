using Core.Application.Responses;

namespace Application.Features.CatalogPaths.Queries.GetById;

public class GetByIdCatalogPathResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int InstructorId { get; set; }
    public int Time { get; set; }
}
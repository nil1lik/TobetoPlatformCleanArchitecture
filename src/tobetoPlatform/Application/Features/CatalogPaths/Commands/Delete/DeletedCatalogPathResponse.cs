using Core.Application.Responses;

namespace Application.Features.CatalogPaths.Commands.Delete;

public class DeletedCatalogPathResponse : IResponse
{
    public int Id { get; set; }
}
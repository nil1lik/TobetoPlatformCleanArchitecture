using Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetById;

public class GetByIdCountryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
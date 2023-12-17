using Core.Application.Responses;

namespace Application.Features.Cities.Commands.Create;

public class CreatedCityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
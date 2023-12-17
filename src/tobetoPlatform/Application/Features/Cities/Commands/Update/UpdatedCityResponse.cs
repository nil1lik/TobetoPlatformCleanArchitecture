using Core.Application.Responses;

namespace Application.Features.Cities.Commands.Update;

public class UpdatedCityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
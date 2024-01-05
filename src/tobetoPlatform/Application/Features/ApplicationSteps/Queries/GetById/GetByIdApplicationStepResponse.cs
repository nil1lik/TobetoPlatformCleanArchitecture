using Core.Application.Responses;

namespace Application.Features.ApplicationSteps.Queries.GetById;

public class GetByIdApplicationStepResponse : IResponse
{
    public int Id { get; set; }
    public int UserApplicationId { get; set; }
    public string Name { get; set; }
    public string? DocumentUrl { get; set; }
    public string? FormUrl { get; set; }
}
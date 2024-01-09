using Core.Application.Responses;

namespace Application.Features.ApplicationSteps.Commands.Update;

public class UpdatedApplicationStepResponse : IResponse
{
    public int Id { get; set; }
    public int UserApplicationId { get; set; }
    public string Name { get; set; }
    public string? DocumentUrl { get; set; }
    public string? FormUrl { get; set; }
}
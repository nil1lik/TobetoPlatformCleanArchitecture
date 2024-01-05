using Core.Application.Responses;

namespace Application.Features.ProfileApplicationSteps.Commands.Update;

public class UpdatedProfileApplicationStepResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicationStepId { get; set; }
    public int ProfileApplicationId { get; set; }
    public bool IsCompleted { get; set; }
}
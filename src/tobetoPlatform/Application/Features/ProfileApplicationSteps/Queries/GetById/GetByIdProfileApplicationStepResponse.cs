using Core.Application.Responses;

namespace Application.Features.ProfileApplicationSteps.Queries.GetById;

public class GetByIdProfileApplicationStepResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicationStepId { get; set; }
    public int ProfileApplicationId { get; set; }
    public bool IsCompleted { get; set; }
}
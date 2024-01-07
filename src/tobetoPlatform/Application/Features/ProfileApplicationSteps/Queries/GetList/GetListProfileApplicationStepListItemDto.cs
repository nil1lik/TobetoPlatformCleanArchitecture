using Core.Application.Dtos;

namespace Application.Features.ProfileApplicationSteps.Queries.GetList;

public class GetListProfileApplicationStepListItemDto : IDto
{
    public int Id { get; set; }
    public int ApplicationStepId { get; set; }
    public int ProfileApplicationId { get; set; }
    public bool IsCompleted { get; set; }
}
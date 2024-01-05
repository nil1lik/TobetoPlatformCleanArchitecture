using Core.Application.Dtos;

namespace Application.Features.ApplicationSteps.Queries.GetList;

public class GetListApplicationStepListItemDto : IDto
{
    public int Id { get; set; }
    public int UserApplicationId { get; set; }
    public string Name { get; set; }
    public string? DocumentUrl { get; set; }
    public string? FormUrl { get; set; }
}
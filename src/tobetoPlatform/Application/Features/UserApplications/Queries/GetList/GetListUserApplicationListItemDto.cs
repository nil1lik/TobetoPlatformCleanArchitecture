using Core.Application.Dtos;

namespace Application.Features.UserApplications.Queries.GetList;

public class GetListUserApplicationListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> ApplicationStepName { get; set; }

}
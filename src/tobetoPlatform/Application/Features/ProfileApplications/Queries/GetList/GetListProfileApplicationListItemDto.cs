using Core.Application.Dtos;

namespace Application.Features.ProfileApplications.Queries.GetList;

public class GetListProfileApplicationListItemDto : IDto
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
}
using Core.Application.Dtos;

namespace Application.Features.ProfileApplicationForms.Queries.GetList;

public class GetListProfileApplicationFormListItemDto : IDto
{
    public int Id { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
    public bool ApprovalStatus { get; set; }
    public string Message { get; set; }
}
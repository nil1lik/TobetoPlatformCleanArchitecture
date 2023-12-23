using Core.Application.Responses;

namespace Application.Features.ProfileApplicationForms.Queries.GetById;

public class GetByIdProfileApplicationFormResponse : IResponse
{
    public int Id { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
    public bool ApprovalStatus { get; set; }
    public string Message { get; set; }
}
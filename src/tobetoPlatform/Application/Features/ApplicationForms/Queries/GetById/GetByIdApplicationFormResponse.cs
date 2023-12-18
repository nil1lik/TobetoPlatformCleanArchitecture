using Core.Application.Responses;

namespace Application.Features.ApplicationForms.Queries.GetById;

public class GetByIdApplicationFormResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }
}
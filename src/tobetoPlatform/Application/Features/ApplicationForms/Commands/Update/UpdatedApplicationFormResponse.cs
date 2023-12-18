using Core.Application.Responses;

namespace Application.Features.ApplicationForms.Commands.Update;

public class UpdatedApplicationFormResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }
}
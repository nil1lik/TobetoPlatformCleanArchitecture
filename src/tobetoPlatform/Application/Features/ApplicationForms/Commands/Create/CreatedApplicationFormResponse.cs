using Core.Application.Responses;

namespace Application.Features.ApplicationForms.Commands.Create;

public class CreatedApplicationFormResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }
}
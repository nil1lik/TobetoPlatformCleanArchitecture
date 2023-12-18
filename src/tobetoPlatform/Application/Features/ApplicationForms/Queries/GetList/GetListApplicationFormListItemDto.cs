using Core.Application.Dtos;

namespace Application.Features.ApplicationForms.Queries.GetList;

public class GetListApplicationFormListItemDto : IDto
{
    public int Id { get; set; }
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }
}
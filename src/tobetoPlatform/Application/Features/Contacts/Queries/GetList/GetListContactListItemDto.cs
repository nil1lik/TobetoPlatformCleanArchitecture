using Core.Application.Dtos;

namespace Application.Features.Contacts.Queries.GetList;

public class GetListContactListItemDto : IDto
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
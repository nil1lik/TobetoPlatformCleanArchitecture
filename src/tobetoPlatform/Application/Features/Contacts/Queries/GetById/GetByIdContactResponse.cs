using Core.Application.Responses;

namespace Application.Features.Contacts.Queries.GetById;

public class GetByIdContactResponse : IResponse
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.Contacts.Commands.Create;

public class CreatedContactResponse : IResponse
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
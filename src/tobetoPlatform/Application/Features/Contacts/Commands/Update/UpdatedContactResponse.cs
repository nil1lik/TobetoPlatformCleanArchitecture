using Core.Application.Responses;

namespace Application.Features.Contacts.Commands.Update;

public class UpdatedContactResponse : IResponse
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
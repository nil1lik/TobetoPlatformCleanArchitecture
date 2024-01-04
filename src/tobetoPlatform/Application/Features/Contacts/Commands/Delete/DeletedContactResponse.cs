using Core.Application.Responses;

namespace Application.Features.Contacts.Commands.Delete;

public class DeletedContactResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.ProfileAddresses.Commands.Delete;

public class DeletedProfileAddressResponse : IResponse
{
    public int Id { get; set; }
}
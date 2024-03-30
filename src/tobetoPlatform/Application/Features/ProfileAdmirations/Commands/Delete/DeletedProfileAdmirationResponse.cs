using Core.Application.Responses;

namespace Application.Features.ProfileAdmirations.Commands.Delete;

public class DeletedProfileAdmirationResponse : IResponse
{
    public int Id { get; set; }
}
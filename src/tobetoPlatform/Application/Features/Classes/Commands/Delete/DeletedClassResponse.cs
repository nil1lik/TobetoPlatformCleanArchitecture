using Core.Application.Responses;

namespace Application.Features.Classes.Commands.Delete;

public class DeletedClassResponse : IResponse
{
    public int Id { get; set; }
}
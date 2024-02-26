using Core.Application.Responses;

namespace Application.Features.ProfileClasses.Commands.Delete;

public class DeletedProfileClassResponse : IResponse
{
    public int Id { get; set; }
}
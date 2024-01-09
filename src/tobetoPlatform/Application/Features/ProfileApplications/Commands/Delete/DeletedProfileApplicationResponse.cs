using Core.Application.Responses;

namespace Application.Features.ProfileApplications.Commands.Delete;

public class DeletedProfileApplicationResponse : IResponse
{
    public int Id { get; set; }
}
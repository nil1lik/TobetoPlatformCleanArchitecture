using Core.Application.Responses;

namespace Application.Features.UserApplications.Commands.Delete;

public class DeletedUserApplicationResponse : IResponse
{
    public int Id { get; set; }
}
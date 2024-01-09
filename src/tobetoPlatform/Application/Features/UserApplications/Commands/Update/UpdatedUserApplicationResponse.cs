using Core.Application.Responses;

namespace Application.Features.UserApplications.Commands.Update;

public class UpdatedUserApplicationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
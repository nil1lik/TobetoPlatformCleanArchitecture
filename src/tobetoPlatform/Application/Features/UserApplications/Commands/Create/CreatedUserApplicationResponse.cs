using Core.Application.Responses;

namespace Application.Features.UserApplications.Commands.Create;

public class CreatedUserApplicationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
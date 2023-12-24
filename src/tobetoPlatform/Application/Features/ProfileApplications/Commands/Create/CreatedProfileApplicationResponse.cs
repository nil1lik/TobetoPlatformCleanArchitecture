using Core.Application.Responses;

namespace Application.Features.ProfileApplications.Commands.Create;

public class CreatedProfileApplicationResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
}
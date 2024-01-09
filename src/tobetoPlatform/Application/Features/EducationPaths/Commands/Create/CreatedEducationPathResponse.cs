using Core.Application.Responses;

namespace Application.Features.EducationPaths.Commands.Create;

public class CreatedEducationPathResponse : IResponse
{
    public int Id { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }
    public int TimeSpentId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
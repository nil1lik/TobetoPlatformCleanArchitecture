using Core.Application.Responses;

namespace Application.Features.EducationPaths.Commands.Update;

public class UpdatedEducationPathResponse : IResponse
{
    public int Id { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
} 
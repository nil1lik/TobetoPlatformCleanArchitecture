using Core.Application.Responses;

namespace Application.Features.EducationPaths.Queries.GetById;

public class GetByIdEducationPathResponse : IResponse
{
    public int Id { get; set; }
    public int ProfileEducationId { get; set; }
    public int EducationAboutId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
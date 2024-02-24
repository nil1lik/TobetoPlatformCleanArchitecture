using Core.Application.Dtos;

namespace Application.Features.EducationPaths.Queries.GetList;

public class GetListEducationPathListItemDto : IDto
{
    public int Id { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationAboutId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
}
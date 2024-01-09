using Core.Application.Dtos;

namespace Application.Features.EducationAbouts.Queries.GetList;

public class GetListEducationAboutListItemDto : IDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
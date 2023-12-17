using Core.Application.Dtos;

namespace Application.Features.Graduations.Queries.GetList;

public class GetListGraduationListItemDto : IDto
{
    public int Id { get; set; }
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.EducationAbouts.Queries.GetById;

public class GetByIdEducationAboutResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string EstimatedDuration { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.EducationAbouts.Commands.Create;

public class CreatedEducationAboutResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
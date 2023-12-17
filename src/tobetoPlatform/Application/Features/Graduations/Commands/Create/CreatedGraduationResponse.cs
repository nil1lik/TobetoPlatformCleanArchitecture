using Core.Application.Responses;

namespace Application.Features.Graduations.Commands.Create;

public class CreatedGraduationResponse : IResponse
{
    public int Id { get; set; }
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }
}
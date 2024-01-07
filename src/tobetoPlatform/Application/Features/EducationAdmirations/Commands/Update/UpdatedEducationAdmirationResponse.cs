using Core.Application.Responses;

namespace Application.Features.EducationAdmirations.Commands.Update;

public class UpdatedEducationAdmirationResponse : IResponse
{
    public int Id { get; set; }
    public bool IsLiked { get; set; }
    public bool IsFavourited { get; set; }
    public double CompletionRate { get; set; }
    public double EducationPoint { get; set; }
}
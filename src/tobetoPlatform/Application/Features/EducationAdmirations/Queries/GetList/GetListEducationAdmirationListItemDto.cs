using Core.Application.Dtos;

namespace Application.Features.EducationAdmirations.Queries.GetList;

public class GetListEducationAdmirationListItemDto : IDto
{
    public int Id { get; set; }
    public bool IsLiked { get; set; }
    public bool IsFavourited { get; set; }
    public double CompletionRate { get; set; }
    public double EducationPoint { get; set; }
}
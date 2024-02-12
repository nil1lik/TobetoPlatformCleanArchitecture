using Core.Application.Dtos;

namespace Application.Features.ProfileGraduations.Queries.GetList;

public class GetListProfileGraduationListItemDto : IDto
{
    public int Id { get; set; }
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }
}
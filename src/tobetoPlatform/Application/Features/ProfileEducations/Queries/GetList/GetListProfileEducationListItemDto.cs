using Core.Application.Dtos;

namespace Application.Features.ProfileEducations.Queries.GetList;

public class GetListProfileEducationListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }
}
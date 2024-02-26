using Core.Application.Dtos;

namespace Application.Features.ProfileClasses.Queries.GetList;

public class GetListProfileClassListItemDto : IDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }
    public int EducationPathId { get; set; }
}
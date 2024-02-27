using Core.Application.Responses;

namespace Application.Features.ProfileClasses.Queries.GetById;

public class GetByIdProfileClassResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }
    public int EducationPathId { get; set; }
}
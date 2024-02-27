using Core.Application.Responses;

namespace Application.Features.ProfileClasses.Commands.Create;

public class CreatedProfileClassResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }
    public int EducationPathId { get; set; }
}
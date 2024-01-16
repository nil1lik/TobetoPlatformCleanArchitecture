using Core.Application.Responses;

namespace Application.Features.ProfileExams.Commands.Create;

public class CreatedProfileExamResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }
}
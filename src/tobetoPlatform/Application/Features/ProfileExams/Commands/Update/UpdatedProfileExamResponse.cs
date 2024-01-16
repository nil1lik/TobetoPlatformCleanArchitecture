using Core.Application.Responses;

namespace Application.Features.ProfileExams.Commands.Update;

public class UpdatedProfileExamResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }
}
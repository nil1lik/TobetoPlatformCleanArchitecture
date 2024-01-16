using Core.Application.Responses;

namespace Application.Features.ProfileExams.Queries.GetById;

public class GetByIdProfileExamResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }
}
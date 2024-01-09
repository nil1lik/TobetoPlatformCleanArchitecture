using Core.Application.Responses;

namespace Application.Features.Skills.Commands.Delete;

public class DeletedSkillResponse : IResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}
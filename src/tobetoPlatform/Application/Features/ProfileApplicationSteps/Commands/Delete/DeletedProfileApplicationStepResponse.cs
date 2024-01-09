using Core.Application.Responses;

namespace Application.Features.ProfileApplicationSteps.Commands.Delete;

public class DeletedProfileApplicationStepResponse : IResponse
{
    public int Id { get; set; }
}
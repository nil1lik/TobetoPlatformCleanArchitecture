using Core.Application.Responses;

namespace Application.Features.ApplicationSteps.Commands.Delete;

public class DeletedApplicationStepResponse : IResponse
{
    public int Id { get; set; }
}
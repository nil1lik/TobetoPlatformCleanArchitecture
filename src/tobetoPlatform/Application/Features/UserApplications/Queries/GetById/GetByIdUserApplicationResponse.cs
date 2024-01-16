using Core.Application.Responses;

namespace Application.Features.UserApplications.Queries.GetById;

public class GetByIdUserApplicationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ApplicationStepName { get; set; }
}
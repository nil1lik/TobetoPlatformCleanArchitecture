using Core.Application.Responses;

namespace Application.Features.ProfileApplicationForms.Commands.Delete;

public class DeletedProfileApplicationFormResponse : IResponse
{
    public int Id { get; set; }
}
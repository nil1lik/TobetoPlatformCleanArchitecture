using Core.Application.Responses;

namespace Application.Features.ApplicationForms.Commands.Delete;

public class DeletedApplicationFormResponse : IResponse
{
    public int Id { get; set; }
}
using Core.Application.Responses;

namespace Application.Features.ProfileLanguages.Commands.Delete;

public class DeletedProfileLanguageResponse : IResponse
{
    public int Id { get; set; }
}
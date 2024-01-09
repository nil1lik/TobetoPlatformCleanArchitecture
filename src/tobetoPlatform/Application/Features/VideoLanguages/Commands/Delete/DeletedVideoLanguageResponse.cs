using Core.Application.Responses;

namespace Application.Features.VideoLanguages.Commands.Delete;

public class DeletedVideoLanguageResponse : IResponse
{
    public int Id { get; set; }
}
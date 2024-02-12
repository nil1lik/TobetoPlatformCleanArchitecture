using Core.Application.Responses;

namespace Application.Features.ProfileLanguages.Commands.Create;

public class CreatedProfileLanguageResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
}
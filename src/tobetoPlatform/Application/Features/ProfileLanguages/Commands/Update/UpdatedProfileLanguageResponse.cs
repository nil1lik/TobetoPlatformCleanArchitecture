using Core.Application.Responses;

namespace Application.Features.ProfileLanguages.Commands.Update;

public class UpdatedProfileLanguageResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
}
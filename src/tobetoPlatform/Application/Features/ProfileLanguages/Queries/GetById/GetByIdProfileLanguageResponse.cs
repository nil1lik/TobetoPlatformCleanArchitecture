using Core.Application.Responses;

namespace Application.Features.ProfileLanguages.Queries.GetById;

public class GetByIdProfileLanguageResponse : IResponse
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int LanguageId { get; set; }
    public int LanguageLevelId { get; set; }
}
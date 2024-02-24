using SharpCompress.Readers;

namespace Application.Features.Experiences.Constants;

public static class ExperiencesBusinessMessages
{
    public const string ExperienceNotExists = "Experience not exists.";
    public const string TheSameWorkCannotBeStartedOnTheSameDate = "Bu tarih aralýðýnda kayýtlý bir deneyiminiz vardýr";
    public const string TheStartDateAndTheEndDateCannotBeDuplicated = "Deneyim baþlangýç tarihi ile bitiþ tarihi ayný olamaz";
    public const string TheStartDateCannotBeGreaterThanTheEndDate = "Baþlangýç tarihi, bitiþ tarihinden büyük olamaz";
}
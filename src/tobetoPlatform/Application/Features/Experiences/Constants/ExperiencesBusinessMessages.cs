using SharpCompress.Readers;

namespace Application.Features.Experiences.Constants;

public static class ExperiencesBusinessMessages
{
    public const string ExperienceNotExists = "Experience not exists.";
    public const string TheSameWorkCannotBeStartedOnTheSameDate = "Bu tarih aral���nda kay�tl� bir deneyiminiz vard�r";
    public const string TheStartDateAndTheEndDateCannotBeDuplicated = "Deneyim ba�lang�� tarihi ile biti� tarihi ayn� olamaz";
    public const string TheStartDateCannotBeGreaterThanTheEndDate = "Ba�lang�� tarihi, biti� tarihinden b�y�k olamaz";
}
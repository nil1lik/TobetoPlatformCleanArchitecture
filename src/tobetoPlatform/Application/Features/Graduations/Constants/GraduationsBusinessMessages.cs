namespace Application.Features.Graduations.Constants;

public static class GraduationsBusinessMessages
{
    public const string GraduationNotExists = "Graduation not exists.";
    public const string TheSameWorkCannotBeStartedOnTheSameDate = "Bu tarih aral���nda kay�tl� bir e�itiminiz vard�r";
    public const string TheStartDateAndTheEndDateCannotBeDuplicated = "E�itimin ba�lang�� tarihi ile biti� tarihi ayn� olamaz";
    public const string TheStartDateCannotBeGreaterThanTheEndDate = "E�itimin ba�lang�� tarihi, biti� tarihinden b�y�k olamaz";
}
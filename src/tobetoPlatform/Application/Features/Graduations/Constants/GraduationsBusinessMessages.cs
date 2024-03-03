namespace Application.Features.Graduations.Constants;

public static class GraduationsBusinessMessages
{
    public const string GraduationNotExists = "Graduation not exists.";
    public const string TheSameWorkCannotBeStartedOnTheSameDate = "Bu tarih aralýðýnda kayýtlý bir eðitiminiz vardýr";
    public const string TheStartDateAndTheEndDateCannotBeDuplicated = "Eðitimin baþlangýç tarihi ile bitiþ tarihi ayný olamaz";
    public const string TheStartDateCannotBeGreaterThanTheEndDate = "Eðitimin baþlangýç tarihi, bitiþ tarihinden büyük olamaz";
}
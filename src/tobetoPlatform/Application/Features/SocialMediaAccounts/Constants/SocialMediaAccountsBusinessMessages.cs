using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Application.Features.SocialMediaAccounts.Constants;

public static class SocialMediaAccountsBusinessMessages
{
    public const string SocialMediaAccountNotExists = "Social media account not exists.";
    public const string SocialMediaAccountsCannotBeMoreThan3 = "En fazla 3 adet medya seçimi yapýlabilir";
    public const string SocialMediaAccountsShouldNotBeDuplicated = "Bu sosyal medya zaten mevcut";
}
using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileLanguage : Entity<int>  
    {
        public int UserProfileId { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Language Language { get; set; }
        public virtual LanguageLevel LanguageLevel { get; set; }


        public ProfileLanguage()
        {
        }

        public ProfileLanguage(int id, int userProfileId, int languageId, int languageLevelId):this()
        {
            Id = id;
            UserProfileId = userProfileId;
            LanguageId = languageId;
            LanguageLevelId = languageLevelId;
        }
    }
}

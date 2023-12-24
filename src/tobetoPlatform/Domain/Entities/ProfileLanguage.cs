using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileLanguage : Entity<int>  
    {
        public int UserProfileId { get; set; }
        public int LanguageId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Language Language { get; set; }

        public ProfileLanguage()
        {
        }

        public ProfileLanguage(int userProfileId, int languageId)
        {
            UserProfileId = userProfileId;
            LanguageId = languageId;
        }

        

    }
}

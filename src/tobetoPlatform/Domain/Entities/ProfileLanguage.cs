using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileLanguage : Entity<int>  //güncellendi
    {
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Language> Languages { get; set; }

    }
}

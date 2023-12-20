using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileSurvey : Entity<int>  //güncellendi
    {
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}

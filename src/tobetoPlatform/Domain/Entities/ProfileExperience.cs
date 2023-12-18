using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileExperience : Entity<int>  //güncellendi
    {
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        
    }
}


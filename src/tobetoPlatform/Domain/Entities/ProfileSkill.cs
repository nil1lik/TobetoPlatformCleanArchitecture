using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileSkill : Entity<int>  //güncellendi
    {
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

       
    }
}



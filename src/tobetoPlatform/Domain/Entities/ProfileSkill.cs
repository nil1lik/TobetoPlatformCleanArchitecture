using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileSkill : Entity<int>  //güncellendi
    {
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }

       
    }
}



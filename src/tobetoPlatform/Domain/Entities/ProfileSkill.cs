using Core.Persistence.Repositories;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities
{
    public class ProfileSkill : Entity<int>  
    {
        public int UserProfileId { get; set; }
        public int SkillId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual Skill Skill { get; set; }

        public ProfileSkill()
        {
        }

        public ProfileSkill(int id , int userProfileId) : this()
        {
            Id = id;
            UserProfileId = userProfileId;
        }

       

       
    }
}



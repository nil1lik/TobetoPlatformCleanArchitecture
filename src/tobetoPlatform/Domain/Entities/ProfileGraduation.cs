using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileGraduation : Entity<int>  //güncellendi
    {
        public virtual ICollection<Graduation> Graduations { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
   
    }
}

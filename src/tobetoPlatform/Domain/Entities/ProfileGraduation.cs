using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileGraduation : Entity<int>  
    {
        public int GraduationId { get; set; }
        public int UserProfileId { get; set; }

        public virtual Graduation Graduation { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public ProfileGraduation()
        {
        }

        public ProfileGraduation(int id, int graduationId, int userProfileId):this()
        {
            Id = id;
            GraduationId = graduationId;
            UserProfileId = userProfileId;
        }
    }
}

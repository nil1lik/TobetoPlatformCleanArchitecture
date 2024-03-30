using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileAdmiration : Entity<int>
    {
        public int UserProfileId { get; set; }
        public int EducationAdmirationId { get; set; }
        public int EducationPathId { get; set; }

        public virtual EducationAdmiration EducationAdmiration { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual EducationPath EducationPath { get; set; }

        public ProfileAdmiration()
        {
        }

        public ProfileAdmiration(int id, int userProfileId, int educationAdmirationId, int educationPathId) : this()
        {
            Id = id;
            UserProfileId = userProfileId;
            EducationAdmirationId = educationAdmirationId;
            EducationPathId = educationPathId;
        }
    }
}



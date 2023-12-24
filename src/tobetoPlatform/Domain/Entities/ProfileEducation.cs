using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileEducation : Entity<int>
{
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual EducationPath EducationPath { get; set; }

    public ProfileEducation()
    {
    }

    public ProfileEducation(int id, int userProfileId, int educationPathId):this()
    {
        Id = id;
        UserProfileId = userProfileId;
        EducationPathId = educationPathId;
    }

    

}
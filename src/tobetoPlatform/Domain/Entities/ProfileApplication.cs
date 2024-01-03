using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileApplication:Entity<int>
{
    public int UserProfileId { get; set; }
    public int ApplicationId { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual Application Application { get; set; }
    public virtual ProfileApplicationStep ProfileApplicationStep{ get; set; }

    public ProfileApplication()
    {
        
    }

    public ProfileApplication(int id ,int userProfileId, int applicationId) : this()
    {
        Id = id;
        UserProfileId = userProfileId;
        ApplicationId = applicationId;
    }
}

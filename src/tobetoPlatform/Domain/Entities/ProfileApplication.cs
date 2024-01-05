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
    public int UserApplicationId { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual UserApplication UserApplication { get; set; }
    public virtual ProfileApplicationStep ProfileApplicationStep{ get; set; }

    public ProfileApplication()
    {
        
    }

    public ProfileApplication(int id ,int userProfileId, int userApplicationId) : this()
    {
        Id = id;
        UserProfileId = userProfileId;
        UserApplicationId = userApplicationId;
    }
}

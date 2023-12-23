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
    public int ProfileId { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }

    public virtual UserProfile UserProfile { get; set; }
    public virtual ApplicationForm ApplicationForm { get; set; }

    public ProfileApplication()
    {
        
    }

    public ProfileApplication(int id ,int profileId, int applicationFormId, string name) : this()
    {
        Id = id;
        ProfileId = profileId;
        ApplicationFormId = applicationFormId;
        Name = name;
    }
}
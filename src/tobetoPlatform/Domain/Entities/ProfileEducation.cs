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
    public virtual ICollection<UserProfile> UserProfiles { get; set; }
    public virtual ICollection<EducationPath> EducationPaths { get; set; }

}
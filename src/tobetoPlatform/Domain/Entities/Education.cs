using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Education : Entity<int>
{
    public int ProfileId { get; set; }
    public virtual Profile Profile { get; set; }
    public virtual ICollection<EducationPath> EducationPaths { get; set; }

    public Education()
    {

    }

    public Education(int id, int profileId) : this()
    {
        Id = id;
        ProfileId = profileId;
    }
}

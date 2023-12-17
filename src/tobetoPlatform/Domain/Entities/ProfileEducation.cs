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
    public Guid ProfileId { get; set; }

    public virtual Profile Profile { get; set; }

    public ProfileEducation()
    {

    }

    public ProfileEducation(int id, Guid profileId) : this()
    {
        Id = id;
        ProfileId = profileId;
    }
}
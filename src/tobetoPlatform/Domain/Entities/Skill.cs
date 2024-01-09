using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Skill : Entity<int>  
{
    public string Name { get; set; }

    public virtual ICollection<ProfileSkill>? ProfileSkills { get; set; }

    public Skill()
    {

    }

    public Skill(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}

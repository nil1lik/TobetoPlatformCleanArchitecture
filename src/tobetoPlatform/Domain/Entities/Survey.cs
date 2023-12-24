using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Survey:Entity<int> 
{
    public string Name { get; set; }

    public virtual ICollection<ProfileSurvey> ProfileSurveys { get; set; }

    public Survey()
    {
        
    }

    public Survey(int id, string name):this()
    {
        Id = id;
        Name = name;
    }
}



using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EducationAboutCategory :Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<EducationAbout> EducationAbouts { get; set; }

    public EducationAboutCategory()
    {
        
    }

    public EducationAboutCategory(int id , string name) : this()
    {
        Id = id;
        Name = name;
    }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Company : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<LessonVideoDetail> LessonVideoDetails { get; set; }
    public virtual ICollection<EducationAbout> EducationAbouts { get; set; }

    public Company()
    {

    }

    public Company(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}


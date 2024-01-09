using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseClass:Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<ProfileClass> ProfileClasses { get; set; }

    public CourseClass()
    {
    }

    public CourseClass(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }

   
}

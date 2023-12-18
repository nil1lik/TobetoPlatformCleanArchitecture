using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseClass:Entity<int>
{
    public int ProfileClassId { get; set; }
    public string Name { get; set; }
    public virtual ProfileClass ProfileClass { get; set; }
}

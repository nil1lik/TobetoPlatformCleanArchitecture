using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class TimeSpent :  Entity<int>
{
    public bool isEnd { get; set; }

    public virtual  ICollection<EducationPath> EducationPaths { get; set; }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileShare :Entity<int>
{
    public int ProfileId { get; set; }
    public bool isShare { get; set; }
    public virtual UserProfile UserProfile { get; set; }
}

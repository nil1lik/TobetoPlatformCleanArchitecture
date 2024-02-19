using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class City : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<District> Districts { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }

    public City()
    {

    }

    public City(string name, int id) : this()
    {
        Id = id;
        Name = name;
    }
}


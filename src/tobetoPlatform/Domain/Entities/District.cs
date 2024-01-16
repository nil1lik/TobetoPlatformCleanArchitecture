using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class District : Entity<int>
{
    public int CityId { get; set; }
    public string Name { get; set; }

    public virtual City City { get; set; }
    public District()
    {

    }

    public District(int id, int cityId, string name):this()
    {
        Id = id;
        CityId = cityId;
        Name = name;
    }
}

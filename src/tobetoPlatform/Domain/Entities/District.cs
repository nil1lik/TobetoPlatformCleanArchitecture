using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class District : Entity<int>
{
    public string Name { get; set; }

    public ICollection<ProfileAddress> ProfileAddresses { get; set; }

    public District()
    {

    }

    public District(string name, int id) : this()
    {
        Id = id;
        Name = name;
    }
}

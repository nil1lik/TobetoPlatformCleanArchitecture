using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Survey:Entity<int>  //güncellendi
{
    public string Name { get; set; }
    public Survey()
    {
        
    }

    public Survey(int id, int profileId, string name):this()
    {
        Id = id;
        Name = name;
    }
}

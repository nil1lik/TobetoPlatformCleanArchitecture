using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class LanguageLevel : Entity<int>
{
    public string Name { get; set; }
    public LanguageLevel()
    {

    }

    public LanguageLevel(string name, int id) : this()
    {
        Id = id;
        Name = name;
    }
}


using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Language : Entity<int>  //güncellendi
{
    public string Name { get; set; }
    public int LanguageLevelId { get; set; }
    public virtual LanguageLevel Level { get; set; }

    public Language()
    {

    }

    public Language(int id,int languageLevelId, string name) : this()
    {
        Id = id;
        LanguageLevelId = languageLevelId;
        Name = name;
    }
}

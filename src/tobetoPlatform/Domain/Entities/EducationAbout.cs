using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EducationAbout : Entity<int>
{
    public int CompanyId { get; set; }
    public int EducationAboutCategoryId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string EstimatedDuration { get; set; } //Tahmini Süre
    

    //Geçirilen Süre ayrı tabloda tutulmalı mı?

    public virtual Company Company { get; set; }
    public virtual EducationAboutCategory EducationAboutCategory { get; set; }

    public EducationAbout()
    {

    }


}


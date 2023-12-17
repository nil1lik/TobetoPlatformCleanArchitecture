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
    public int EducationPathCategoryId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string EstimatedDuration { get; set; } //Tahmini Süre

    //Geçirilen Süre ayrı tabloda tutulmalı mı?

    public string Content { get; set; }
    public string Video { get; set; }
    public string? Task { get; set; } //Content, Video ve Task ayrı tabloda tutulmalı mı? EducationAboutContent???
    public virtual Company Company { get; set; }
    public virtual EducationPathCategory EducationPathCategory { get; set; }

    public EducationAbout()
    {

    }


}


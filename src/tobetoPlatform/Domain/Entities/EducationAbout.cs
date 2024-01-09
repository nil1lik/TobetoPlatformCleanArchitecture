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
    

    public virtual Company Company { get; set; }
    public virtual EducationAboutCategory EducationAboutCategory { get; set; }
    public virtual ICollection<EducationPath> EducationPaths { get; set; }

    public EducationAbout()
    {

    }

    public EducationAbout(int id, int companyId, int educationAboutCategoryId, DateTime startDate, DateTime endDate) : this()
    {
        Id = id;
        CompanyId = companyId;
        EducationAboutCategoryId = educationAboutCategoryId;
        StartDate = startDate;
        EndDate = endDate;
    }
}



using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Graduation : Entity<int>  
{
    public string Degree { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime GraduationDate { get; set; }

    public virtual ICollection<ProfileGraduation> ProfileGraduations { get; set; }

    public Graduation()
    {

    }

    public Graduation(int id, string degree, string universityName, string department, DateTime startDate, DateTime endDate, DateTime graduationDate) : this()
    {
        Id = id;
        Degree = degree;
        UniversityName = universityName;
        Department = department;
        StartDate = startDate;
        EndDate = endDate;
        GraduationDate = graduationDate;
    }
}

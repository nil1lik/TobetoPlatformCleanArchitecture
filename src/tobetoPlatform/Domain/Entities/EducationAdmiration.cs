using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class EducationAdmiration : Entity<int>
{
    public bool IsLiked { get; set; }
    public bool IsFavourited { get; set; }
    public bool CompletionRate { get; set; } // Bool mu olacak?
    public double EducationPoint { get; set; }

    public virtual ICollection<EducationPath> EducationPaths { get; set; }

    public EducationAdmiration()
    {

    }

    public EducationAdmiration(int id, bool isLiked, bool isFavourited, bool completionRate, double educationPoint) : this()
    {
        Id = id;
        IsLiked = isLiked;
        IsFavourited = isFavourited;
        CompletionRate = completionRate;
        EducationPoint = educationPoint;
    }
}

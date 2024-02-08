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
    public double CompletionRate { get; set; } 
    public double EducationPoint { get; set; }

    public virtual ICollection<EducationPath> EducationPaths { get; set; }

    public EducationAdmiration()
    {
        this.IsLiked = false;
        this.IsFavourited = false;
        this.CompletionRate = 0;
        this.EducationPoint = 0;
    }

    public EducationAdmiration(int id, bool isLiked, bool isFavourited, double completionRate, double educationPoint) : this()
    {
        Id = id;
        IsLiked = isLiked;
        IsFavourited = isFavourited;
        CompletionRate = completionRate;
        EducationPoint = educationPoint;
    }
}

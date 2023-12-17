using Core.Persistence.Repositories;

namespace Domain.Entities;

public class EducationPathCategory:Entity<int>
{
    public int EducationPathId { get; set; }
    public string Name { get; set; }

    public virtual EducationPath EducationPath { get; set; }

    public EducationPathCategory()
    {
        
    }


}
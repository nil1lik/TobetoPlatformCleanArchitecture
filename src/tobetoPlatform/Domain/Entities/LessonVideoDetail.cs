using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LessonVideoDetail : Entity<int>
{
    public int VideoLanguageId { get; set; }
    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
    public virtual VideoLanguage VideoLanguage { get; set; }

    public virtual ICollection<LessonVideoDetailVideoDetailCategory> LessonVideoDetailVideoDetailCategories { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }
    public virtual ICollection<SyncLesson> SyncLessons { get; set; }


    public LessonVideoDetail()
    {
    }

    public LessonVideoDetail(int id,int videoLanguageId, int? companyId):this()
    {
        Id = id;
        VideoLanguageId = videoLanguageId;
        CompanyId = companyId;
    }

   
}


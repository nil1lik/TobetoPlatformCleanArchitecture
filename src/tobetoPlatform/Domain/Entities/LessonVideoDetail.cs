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
    public int CategoryId { get; set; }
    public int? SubcategoryId { get; set; }
    public int? CompanyId { get; set; }

    public virtual Company Company { get; set; }
    public virtual VideoDetailCategory Category { get; set; }
    public virtual VideoDetailSubcategory Subcategory { get; set; }
    public virtual VideoLanguage VideoLanguage { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }

    public LessonVideoDetail()
    {
    }

    public LessonVideoDetail(int id,int videoLanguageId, int categoryId, int? subcategoryId, int? companyId, Company company):this()
    {
        Id = id;
        VideoLanguageId = videoLanguageId;
        CategoryId = categoryId;
        SubcategoryId = subcategoryId;
        CompanyId = companyId;
        Company = company;
    }

   
}


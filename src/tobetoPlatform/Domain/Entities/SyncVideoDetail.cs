using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SyncVideoDetail : Entity<int>
{
    public int VideoLanguageId { get; set; }
    public int CategoryId { get; set; }
    public int? SubcategoryId { get; set; }

    public virtual VideoDetailCategory Category { get; set; }
    public virtual VideoDetailSubcategory Subcategory { get; set; }
    public virtual VideoLanguage VideoLanguage { get; set; }
}

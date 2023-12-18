using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ApplicationForm:Entity<int>
{
    public int ProfileDocumentFormId { get; set; }
    public int ProfileApplicationFormId { get; set; }
    public string Name { get; set; }

    public virtual ProfileApplicationForm ProfileApplicationForm { get; set; }
    public virtual ProfileDocumentForm ProfileDocumentForm { get; set; }
}
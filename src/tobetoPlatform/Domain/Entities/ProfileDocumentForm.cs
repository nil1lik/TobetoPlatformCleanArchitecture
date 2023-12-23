using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileDocumentForm:Entity<int>
{
    public int ApplicationFormId { get; set; } 
    public string Name { get; set; }
    public bool ApprovalStatus { get; set; }
    public string DocumentFormUrl { get; set; }
    public string Message { get; set; }

    public virtual ApplicationForm ApplicationForm { get; set; }

    public ProfileDocumentForm()
    {
        
    }

    public ProfileDocumentForm(int id, int applicationFormId, string name, bool approvalStatus, string documentFormUrl, string message) : this()
    {
        Id = id;
        ApplicationFormId = applicationFormId;
        Name = name;
        ApprovalStatus = approvalStatus;
        DocumentFormUrl = documentFormUrl;
        Message = message;
    }
}

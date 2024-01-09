using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Certificate : Entity<int>
{
    public int UserProfileId { get; set; }
    public string Name { get; set; }
    public string FileUrl { get; set; }
    public string FileType { get; set; }

    public virtual UserProfile UserProfile { get; set; }

    public Certificate()
    {

    }

    public Certificate(int userProfileId, string name, string fileUrl, string fileType, int id) : this()
    {
        Id = id;
        Name = name;
        UserProfileId = userProfileId;
        FileUrl = fileUrl;
        FileType = fileType;
    }
}


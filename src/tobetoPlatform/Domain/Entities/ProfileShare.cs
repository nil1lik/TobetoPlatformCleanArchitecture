using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ProfileShare :Entity<int>
{
    public Guid ProfileUrl { get; set; }
    public bool IsShare { get; set; }

    public virtual ICollection<UserProfile> UserProfiles{ get; set; }

    public ProfileShare()
    {
    }

    public ProfileShare(int id, Guid profileUrl,  bool isShare) : this()
    {
        Id = id;
        ProfileUrl = profileUrl;
        IsShare = isShare;
    }

}

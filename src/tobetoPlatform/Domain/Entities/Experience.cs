using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Experience:Entity<int>  
{
    public int UserProfileId { get; set; }
    public int CityId { get; set; }
    public string OrganizationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public virtual City City { get; set; }

    public Experience()
    {

    }

    public Experience(int id, int cityId, string organizationName, string position, string sector, DateTime startDate, DateTime endDate, string description) : this()
    {
        Id = id;
        CityId = cityId;
        OrganizationName = organizationName;
        Position = position;
        Sector = sector;
        StartDate = startDate;
        EndDate = endDate;
        Description = description;
    }
}

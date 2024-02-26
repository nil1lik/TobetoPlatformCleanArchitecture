using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileAddress : Entity<int>  
    {
        public int UserProfileId { get; set; }
        public int CityId { get; set; }
        public string? AddressDetail { get; set; }

        public virtual City City { get; set; }

        public ProfileAddress() 
        {
            

        }

        public ProfileAddress(int id,int userProfileId, int cityId, string addressDetail) : this()
        {
            Id = id;
            UserProfileId = userProfileId;
            CityId = cityId;
            AddressDetail = addressDetail; 
        }
    }
}


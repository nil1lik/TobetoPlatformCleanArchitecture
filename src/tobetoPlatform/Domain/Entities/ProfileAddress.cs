using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileAddress : Entity<int>  
    {
        public int UserProfileId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string AddressDetail { get; set; }

        public virtual Country Country{ get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public ProfileAddress() 
        {
            

        }

        public ProfileAddress(int id, int countryId,int userProfileId, int cityId, int districtId, string addressDetail) : this()
        {
            Id = id;
            CountryId = countryId;
            UserProfileId = userProfileId;
            CityId = cityId;
            DistrictId = districtId;
            AddressDetail = addressDetail; 
        }
    }
}


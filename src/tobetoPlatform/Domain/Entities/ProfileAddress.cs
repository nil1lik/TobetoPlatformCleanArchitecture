using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileAddress : Entity<int>  
    {
        //ProfileId tutulamalı -> teke tek 
        public int ProfileId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string AddressDetail { get; set; }

        public virtual Country Country{ get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Profile Profile { get; set; }

        public ProfileAddress() 
        {
            

        }

        public ProfileAddress(int id, int countryId, int cityId, int districtId, string addressDetail) : this()
        {
            Id = id;
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            AddressDetail = addressDetail; 
        }
    }
}


using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetUserDetail;
public class GetUserDetailDto : IDto
{
    public int UserId { get; set; }
    public int UserProfileId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int CityId{ get; set; }
    public int DistrictId { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
}
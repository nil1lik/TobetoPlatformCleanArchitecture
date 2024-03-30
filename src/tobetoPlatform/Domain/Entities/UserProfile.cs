using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserProfile : Entity<int>
{
    public int UserId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
    public virtual User User { get; set; }
    public virtual City City { get; set; }
    public virtual District District { get; set; }

    public virtual ICollection<ProfileApplication> ProfileApplications { get; set; }
    public virtual ICollection<Graduation> Graduations { get; set; }
    public virtual ICollection<ProfileLanguage>? ProfileLanguages { get; set; }
    public virtual ICollection<ProfileSkill>? ProfileSkills { get; set; }
    public virtual ICollection<ProfileExam>? ProfileExams { get; set; }
    public virtual ICollection<ProfileSurvey>? ProfileSurveys { get; set; }
    public virtual ICollection<ProfileAnnouncement>? ProfileAnnouncement { get; set; }
    public virtual ICollection<ProfileClass>? ProfileClasses { get; set; }
    public virtual ICollection<ProfileEducation>? ProfileEducations { get; set; }
    public virtual ICollection<ProfileLesson>? ProfileLessons { get; set; }
    public virtual ICollection<Certificate>? Certificates { get; set; }
    public virtual ICollection<Experience>? Experiences { get; set; }
    public virtual ICollection<SocialMediaAccount>? SocialMediaAccounts { get; set; }

    public UserProfile()
    {

    }

    public UserProfile(int id,int userId, int cityId, int districtId, string nationalIdentity, string phone, DateTime birthDate, string country, string? addressDetail, string? description, User user)
    {
        Id = id;
        UserId = userId;
        CityId = cityId;
        DistrictId = districtId;
        NationalIdentity = nationalIdentity;
        Phone = phone;
        BirthDate = birthDate;
        Country = country;
        AddressDetail = addressDetail;
        Description = description;
        User = user;
    }
}

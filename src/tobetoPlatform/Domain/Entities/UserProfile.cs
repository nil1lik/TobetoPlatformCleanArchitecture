using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserProfile:Entity<int>
{
    public int UserId { get; set; }
    public int ProfileAddressId { get; set; }
    public int ProfileShareId { get; set; }
    public int ProfileExperienceId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }


    public virtual User User { get; set; }

    public virtual ICollection<ProfileApplication> ProfileApplications { get; set; }

    public virtual ProfileShare ProfileShare { get; set; }
    public virtual ProfileAddress ProfileAddress { get; set; }

    public virtual ICollection<ProfileGraduation> ProfileGraduation { get; set; }
    public virtual ICollection<ProfileLanguage>? ProfileLanguages { get; set; }
    public virtual ICollection<ProfileSkill>? ProfileSkills { get; set; }

    public virtual ICollection<ProfileExam>? ProfileExams { get; set; }

    public virtual ICollection<ProfileSurvey>? ProfileSurveys { get; set; }
    public virtual ICollection<ProfileAnnouncement>? ProfileAnnouncement { get; set; }
    public virtual ICollection<ProfileClass>? ProfileClasses { get; set; }
    public virtual ICollection<ProfileEducation>? ProfileEducations { get; set; }
    public virtual ICollection<Certificate>? Certificates { get; set; }
    public virtual ICollection<Experience>? Experiences { get; set; }
    public virtual ICollection<SocialMediaAccount>? SocialMediaAccounts { get; set; }

    
    public UserProfile()
    {
        
    }

    public UserProfile(int id, int userId, int profileAddressId, int profileShareId, int profileExperienceId, string nationalIdentity, string phone, DateTime birthDate, string? description) : this()
    {
        Id = id;
        UserId = userId;
        ProfileAddressId = profileAddressId;
        ProfileShareId = profileShareId;
        ProfileExperienceId = profileExperienceId;
        NationalIdentity = nationalIdentity;
        Phone = phone;
        BirthDate = birthDate;
        Description = description;
    }
}

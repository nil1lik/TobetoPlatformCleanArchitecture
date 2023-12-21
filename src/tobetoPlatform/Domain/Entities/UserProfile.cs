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
    public int ProfileApplicationId { get; set; }
    public int ProfileAddressId { get; set; }
    public int ProfileClassId { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public int ProfileGraduationId { get; set; }
    public int ProfileLanguageId { get; set; }
    public int ProfileSkillId { get; set; }
    public int ProfileExperienceId { get; set; }
    public int ProfileExamId { get; set; }
    public int ProfileSurveyId { get; set; }
    public int ProfileEducationId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }


    public virtual User User { get; set; }
    public virtual ProfileApplication ProfileApplication { get; set; }
    public virtual ProfileAddress ProfileAddress { get; set; }
    public virtual ProfileGraduation ProfileGraduation { get; set; }
    public virtual ProfileLanguage? ProfileLanguage { get; set; }
    public virtual ProfileSkill? ProfileSkill { get; set; }
    public virtual ProfileExam? ProfileExam { get; set; }
    public virtual ProfileSurvey? ProfileSurvey { get; set; }
    public virtual ProfileAnnouncement? ProfileAnnouncement { get; set; }
    public virtual ProfileClass? ProfileClass { get; set; }
    public virtual ProfileEducation? ProfileEducation { get; set; }
    public virtual ICollection<Certificate>? Certificates { get; set; }
    public virtual ICollection<Experience>? Experiences { get; set; }
    public virtual ICollection<SocialMediaAccount>? SocialMediaAccounts { get; set; }


    public UserProfile()
    {

    }

    public UserProfile(int id, int userId, int profileAddressId, int profileClassId, int profileAnnouncementId, int profileGraduationId, int profileLanguageId, int profileSkillId, int profileExperienceId, int profileExamId, int profileSurveyId, string nationalIdentity, string phone, DateTime birthDate, string? description):this()
    {
        Id = id;
        UserId = userId;
        ProfileAddressId = profileAddressId;
        ProfileClassId = profileClassId;
        ProfileAnnouncementId = profileAnnouncementId;
        ProfileGraduationId = profileGraduationId;
        ProfileLanguageId = profileLanguageId;
        ProfileSkillId = profileSkillId;
        ProfileExperienceId = profileExperienceId;
        ProfileExamId = profileExamId;
        ProfileSurveyId = profileSurveyId;
        NationalIdentity = nationalIdentity;
        Phone = phone;
        BirthDate = birthDate;
        Description = description;
    }
}

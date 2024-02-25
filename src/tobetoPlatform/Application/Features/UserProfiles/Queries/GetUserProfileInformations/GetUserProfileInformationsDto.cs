using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetUserProfileInformations;
public class GetUserProfileInformationsDto:IResponse
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ExamName { get; set; }
    public string ExamDuration { get; set; }
    //public DateTime ExamCreatedDate { get; set; }
    public string SkillName { get; set; }
    public string Language { get; set; }
    public string LanguageLevel { get; set; }
    public string CertificateName { get; set; }
    public string CertificateType { get; set; }
    //public DateTime ExperienceStartDate { get; set; }
    //public DateTime ExperienceEndDate { get; set; }
    public string OrganisationName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public string UniversityName { get; set; }
    public string Department { get; set; }
    //public DateTime GraduationStartDate { get; set; }
    //public DateTime GraduationEndDate { get; set; }
    public string SocialMediaCategoryName { get; set; }
    public string SocialMediaUrl { get; set; }

}

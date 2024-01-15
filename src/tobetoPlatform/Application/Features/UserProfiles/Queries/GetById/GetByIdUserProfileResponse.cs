using Core.Application.Responses;

namespace Application.Features.UserProfiles.Queries.GetById;

public class GetByIdUserProfileResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    //public int ProfileAddressId { get; set; }
    //public int ProfileShareId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Description { get; set; }
    //public DateTime GradutionStartDate { get; set; }
    //public DateTime GradutionEndDate { get; set; }
    //public string UniversityName { get; set; }
    //public string Department { get; set; }
    //public string CertificateFileUrl { get; set; }
    //public string SocialMediaUrl { get; set; }
    //public string Language { get; set; }
    //public string LanguageLevel { get; set; }
    //public string Skill { get; set; }
    //public string Exam { get; set; }
    //public int ExamPoint { get; set; }
    //public DateTime ExamCreatedDate { get; set; }

    

    //public string NationalIdentity { get; set; }
}
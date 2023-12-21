using Core.Application.Responses;

namespace Application.Features.UserProfiles.Queries.GetById;

public class GetByIdUserProfileResponse : IResponse
{
    public Guid Id { get; set; }
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
}
using Application.Features.UserProfiles.Queries.GetAllCertificatesByUserId;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetAllExamsByUserId;
public class GetAllExamsByUserIdResponse:IResponse
{
    public int UserProfileId { get; set; }
    public List<ExamsDtoItems> ExamsDtoItems { get; set; }
}

public class ExamsDtoItems
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public string ExamName { get; set; }
    public string ExamDuration { get; set; }
    public DateTime ExamCreatedDate { get; set; }
    public int QuestionCount { get; set; }
    public bool IsCompleted { get; set; }
}

using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Queries.GetList;
public class GetListExamResultDto:IDto
{
    public int ExamPoint { get; set; }
    public DateTime ExamResultCreatedDate { get; set; }
}

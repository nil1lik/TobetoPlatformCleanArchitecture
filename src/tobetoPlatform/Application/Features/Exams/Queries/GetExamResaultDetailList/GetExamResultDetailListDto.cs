﻿using Core.Application.Dtos;
using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Exams.Queries.GetExamResaultDetailList;
public class GetExamResultDetailListDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ExamPoint { get; set; }
    public DateTime ExamResultCreatedDate { get; set; }
}

using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ExamResult:Entity<int>
{
    public int ExamStatusId { get; set; }
    public int Correct { get; set; }
    public int Wrong { get; set; }
    public int Empty { get; set; }
    public int Point { get; set; }

    public ExamResult()
    {

    }

    public ExamResult(int id, int examStatusId, int correct, int wrong, int empty, int point) : this()
    {
        Id = id;
        ExamStatusId = examStatusId;
        Correct = correct;
        Wrong = wrong;
        Empty = empty;
        Point = point;
    }
}

using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileExam : Entity<int> 
    {
        public int UserProfileId { get; set; }
        public int ExamId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual Exam Exam { get; set; }

        public ProfileExam()
        {
        }

        public ProfileExam(int id,int userProfileId, int examId):this()
        {
            Id = id;
            UserProfileId = userProfileId;
            ExamId = examId;
        }

        

    }
}


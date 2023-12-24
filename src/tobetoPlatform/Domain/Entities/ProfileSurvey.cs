using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileSurvey : Entity<int> 
    {
        public int SurveyId { get; set; }
        public int UserProfileId { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public ProfileSurvey()
        {
        }

        public ProfileSurvey(int id , int surveyId, int userProfileId) : this()
        {
            Id = id;
            SurveyId = surveyId;
            UserProfileId = userProfileId;
        }

       
    }
}

 
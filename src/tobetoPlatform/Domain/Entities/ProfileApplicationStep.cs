using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ProfileApplicationStep : Entity<int>
    {
        //public int ApplicationStepId { get; set; }
        public int ProfileApplicationId { get; set; }
        public bool IsCompleted { get; set; }

        //public virtual ApplicationStep ApplicationStep { get; set; }
        public virtual ProfileApplication ProfileApplication { get; set; }

        public ProfileApplicationStep()
        {
        }

        public ProfileApplicationStep(int id,int applicationStepId, int profileApplicationId, bool isCompleted) : this()
        {
            Id = id;
            //ApplicationStepId = applicationStepId;
            ProfileApplicationId = profileApplicationId;
            IsCompleted = isCompleted;
        }
    }
}




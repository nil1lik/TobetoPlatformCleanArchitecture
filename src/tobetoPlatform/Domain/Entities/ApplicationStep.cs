using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ApplicationStep : Entity<int>
    {
        public int UserApplicationId { get; set; }
        public string Name { get; set; }

        public virtual UserApplication UserApplication { get; set; }
        public virtual ICollection<ProfileApplicationStep> ProfileApplicationSteps { get; set; }

        public ApplicationStep()
        {
        }

        public ApplicationStep(int id, int userApplicationId, string name) : this()
        {
            Id = id;
            UserApplicationId = userApplicationId;
            Name = name;
        }
    } 
}






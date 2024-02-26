using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class ApplicationStep : Entity<int>
    {
        public int UserApplicationId { get; set; }
        public string Name { get; set; }
        public string? DocumentUrl { get; set; }
        public string? FormUrl { get; set; }

        public virtual UserApplication UserApplication { get; set; }
        public virtual ICollection<ProfileApplicationStep> ProfileApplicationSteps { get; set; }

        public ApplicationStep()
        {
        }

        public ApplicationStep(int id, int userApplicationId, string name, string? documentUrl, string? formUrl) : this()
        {
            Id = id;
            UserApplicationId = userApplicationId;
            Name = name;
            DocumentUrl = documentUrl;
            FormUrl = formUrl;
        }
    } 
}






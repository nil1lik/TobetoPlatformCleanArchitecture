using Core.Application.Responses;
using System;
namespace Application.Features.EducationPaths.Queries.GetEducationPathDetailById
{
    public class GetEducationPathDetailByIdDto : IResponse
    {
        public int Id { get; set; }
        public int EducationAboutId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFavourited { get; set; }
        public double CompletionRate { get; set; }
        public double EducationPoint { get; set; }
        //public DateTime StartDate { get; set; }

    }
}



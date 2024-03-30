using Core.Application.Responses;
using System;
namespace Application.Features.UserProfiles.Queries.GetAllAdmirationsByUserId
{
    public class GetAllAdmirationsByUserIdResponse : IResponse
    {
        public int UserProfileId { get; set; }
        public List<ProfileAdmirationItem> ProfileAdmirationItems { get; set; }
    }
    public class ProfileAdmirationItem
    {
        public int Id { get; set; }
        public int EducationPathId { get; set; }
        public int EducationAdmirationId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFavourited { get; set; }
        public double CompletionRate { get; set; }
        public double EducationPoint { get; set; }
    }
}


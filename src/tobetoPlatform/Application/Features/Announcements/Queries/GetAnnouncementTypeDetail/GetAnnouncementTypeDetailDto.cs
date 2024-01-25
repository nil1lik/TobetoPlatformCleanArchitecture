using Core.Application.Dtos;
using System;
namespace Application.Features.Announcements.Queries.GetAnnouncementDetail
{
    public class GetAnnouncementTypeDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string AnnouncementTypeName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}


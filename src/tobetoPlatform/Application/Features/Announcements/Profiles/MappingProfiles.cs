using Application.Features.Announcements.Commands.Create;
using Application.Features.Announcements.Commands.Delete;
using Application.Features.Announcements.Commands.Update;
using Application.Features.Announcements.Queries.GetById;
using Application.Features.Announcements.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.Announcements.Queries.GetAnnouncementDetail;
using Application.Features.Announcements.Queries.GetAnnouncementTypeDetailList;
using OtpNet;

namespace Application.Features.Announcements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Announcement, CreateAnnouncementCommand>().ReverseMap();
        CreateMap<Announcement, CreatedAnnouncementResponse>().ReverseMap();
        CreateMap<Announcement, UpdateAnnouncementCommand>().ReverseMap();
        CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();
        CreateMap<Announcement, DeleteAnnouncementCommand>().ReverseMap();
        CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();
        CreateMap<Announcement, GetByIdAnnouncementResponse>().ReverseMap();
        CreateMap<Announcement, GetListAnnouncementListItemDto>().ReverseMap();
        CreateMap<Announcement, GetAnnouncementTypeDetailListDto>()
            .ForMember(a => a.AnnouncementTypeName, opt => opt.MapFrom(a => a.AnnouncementType.Name))
            .ReverseMap();
        CreateMap<Announcement, GetAnnouncementTypeDetailDto>().
            ForMember(a => a.AnnouncementTypeName, opt => opt.MapFrom(a => a.AnnouncementType.Name))
            .ReverseMap(); 
        CreateMap<IPaginate<Announcement>, GetListResponse<GetListAnnouncementListItemDto>>().ReverseMap();
        CreateMap<IPaginate<Announcement>, GetListResponse<GetAnnouncementTypeDetailListDto>>().ReverseMap(); 
          
    }
}


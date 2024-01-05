using Application.Features.Calendars.Commands.Create;
using Application.Features.Calendars.Commands.Delete;
using Application.Features.Calendars.Commands.Update;
using Application.Features.Calendars.Queries.GetById;
using Application.Features.Calendars.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Calendars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Calendar, CreateCalendarCommand>().ReverseMap();
        CreateMap<Calendar, CreatedCalendarResponse>().ReverseMap();
        CreateMap<Calendar, UpdateCalendarCommand>().ReverseMap();
        CreateMap<Calendar, UpdatedCalendarResponse>().ReverseMap();
        CreateMap<Calendar, DeleteCalendarCommand>().ReverseMap();
        CreateMap<Calendar, DeletedCalendarResponse>().ReverseMap();
        CreateMap<Calendar, GetByIdCalendarResponse>().ReverseMap();
        CreateMap<Calendar, GetListCalendarListItemDto>().ReverseMap();
        CreateMap<IPaginate<Calendar>, GetListResponse<GetListCalendarListItemDto>>().ReverseMap();
    }
}
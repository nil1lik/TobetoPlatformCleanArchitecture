using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Announcements.Queries.GetList;

public class GetListAnnouncementQuery : IRequest<GetListResponse<GetListAnnouncementListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAnnouncementQueryHandler : IRequestHandler<GetListAnnouncementQuery, GetListResponse<GetListAnnouncementListItemDto>>
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper _mapper;

        public GetListAnnouncementQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAnnouncementListItemDto>> Handle(GetListAnnouncementQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Announcement> announcements = await _announcementRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAnnouncementListItemDto> response = _mapper.Map<GetListResponse<GetListAnnouncementListItemDto>>(announcements);
            return response;
        }
    }
}
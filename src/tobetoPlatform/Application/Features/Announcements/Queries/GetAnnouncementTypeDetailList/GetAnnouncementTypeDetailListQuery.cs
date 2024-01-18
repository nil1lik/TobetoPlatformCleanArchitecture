using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Announcements.Queries.GetAnnouncementTypeDetailList
{
    public class GetAnnouncementTypeDetailListQuery : IRequest<GetListResponse<GetAnnouncementTypeDetailListDto>>
    {
        public PageRequest PageRequest { get; set; }

       public class GetAnnouncementTypeDetailListQueryHandler : IRequestHandler<GetAnnouncementTypeDetailListQuery, GetListResponse<GetAnnouncementTypeDetailListDto>>
        {
            private readonly IAnnouncementRepository _announcementRepository;
            private readonly IMapper _mapper; 

            public GetAnnouncementTypeDetailListQueryHandler(IAnnouncementRepository announcementRepository, IMapper mapper)
            {
                _announcementRepository = announcementRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAnnouncementTypeDetailListDto>> Handle(GetAnnouncementTypeDetailListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Announcement> announcements = await _announcementRepository.GetListAsync(
                    include: a => a.Include(a=>a.AnnouncementType), 
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                    );
                
                GetListResponse<GetAnnouncementTypeDetailListDto> response = _mapper.Map<GetListResponse<GetAnnouncementTypeDetailListDto>>(announcements);
                return response;
            } 

        }
    }
}


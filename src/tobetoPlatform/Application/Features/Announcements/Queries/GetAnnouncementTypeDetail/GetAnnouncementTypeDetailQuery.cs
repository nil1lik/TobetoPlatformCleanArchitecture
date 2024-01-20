using Application.Features.Announcements.Queries.GetAnnouncementDetail;
using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Announcements.Queries.GetAnnouncementTypeDetail
{
    public class GetAnnouncementTypeDetailQuery : IRequest<GetAnnouncementTypeDetailDto>
    {
        public int Id { get; set; }

        public class GetAnnouncementTypeDetailQueryHandler : IRequestHandler<GetAnnouncementTypeDetailQuery, GetAnnouncementTypeDetailDto>
        {
            private readonly IMapper _mapper;
            private readonly IAnnouncementRepository _announcementRepository;
            private readonly AnnouncementBusinessRules _announcementBusinessRules;

            public GetAnnouncementTypeDetailQueryHandler(IMapper mapper, IAnnouncementRepository announcementRepository, AnnouncementBusinessRules announcementBusinessRules)
            {
                _mapper = mapper;
                _announcementRepository = announcementRepository;
                _announcementBusinessRules = announcementBusinessRules;
            }

            public async Task<GetAnnouncementTypeDetailDto> Handle(GetAnnouncementTypeDetailQuery request, CancellationToken cancellationToken)
            {
                Announcement? announcement = await _announcementRepository.GetAsync(
                    predicate: a => a.Id == request.Id,
                    include: a => a.Include(a => a.AnnouncementType),
                    cancellationToken: cancellationToken);
                await _announcementBusinessRules.AnnouncementShouldExistWhenSelected(announcement);

                GetAnnouncementTypeDetailDto response = _mapper.Map<GetAnnouncementTypeDetailDto>(announcement);
                return response; 
            }
        }
         
        
    }
}

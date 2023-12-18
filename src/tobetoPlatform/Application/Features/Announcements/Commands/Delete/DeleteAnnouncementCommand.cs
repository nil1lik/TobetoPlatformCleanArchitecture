using Application.Features.Announcements.Constants;
using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Announcements.Commands.Delete;

public class DeleteAnnouncementCommand : IRequest<DeletedAnnouncementResponse>
{
    public int Id { get; set; }

    public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, DeletedAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly AnnouncementBusinessRules _announcementBusinessRules;

        public DeleteAnnouncementCommandHandler(IMapper mapper, IAnnouncementRepository announcementRepository,
                                         AnnouncementBusinessRules announcementBusinessRules)
        {
            _mapper = mapper;
            _announcementRepository = announcementRepository;
            _announcementBusinessRules = announcementBusinessRules;
        }

        public async Task<DeletedAnnouncementResponse> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            Announcement? announcement = await _announcementRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementBusinessRules.AnnouncementShouldExistWhenSelected(announcement);

            await _announcementRepository.DeleteAsync(announcement!);

            DeletedAnnouncementResponse response = _mapper.Map<DeletedAnnouncementResponse>(announcement);
            return response;
        }
    }
}
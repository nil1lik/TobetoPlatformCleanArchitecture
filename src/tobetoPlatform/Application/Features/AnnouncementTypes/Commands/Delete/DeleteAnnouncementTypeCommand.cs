using Application.Features.AnnouncementTypes.Constants;
using Application.Features.AnnouncementTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AnnouncementTypes.Commands.Delete;

public class DeleteAnnouncementTypeCommand : IRequest<DeletedAnnouncementTypeResponse>
{
    public int Id { get; set; }

    public class DeleteAnnouncementTypeCommandHandler : IRequestHandler<DeleteAnnouncementTypeCommand, DeletedAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public DeleteAnnouncementTypeCommandHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository,
                                         AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<DeletedAnnouncementTypeResponse> Handle(DeleteAnnouncementTypeCommand request, CancellationToken cancellationToken)
        {
            AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(predicate: at => at.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementTypeBusinessRules.AnnouncementTypeShouldExistWhenSelected(announcementType);

            await _announcementTypeRepository.DeleteAsync(announcementType!);

            DeletedAnnouncementTypeResponse response = _mapper.Map<DeletedAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}
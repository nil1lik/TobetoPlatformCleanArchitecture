using Application.Features.AnnouncementTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AnnouncementTypes.Commands.Create;

public class CreateAnnouncementTypeCommand : IRequest<CreatedAnnouncementTypeResponse>
{
    public string Name { get; set; }

    public class CreateAnnouncementTypeCommandHandler : IRequestHandler<CreateAnnouncementTypeCommand, CreatedAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public CreateAnnouncementTypeCommandHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository,
                                         AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<CreatedAnnouncementTypeResponse> Handle(CreateAnnouncementTypeCommand request, CancellationToken cancellationToken)
        {
            AnnouncementType announcementType = _mapper.Map<AnnouncementType>(request);

            await _announcementTypeRepository.AddAsync(announcementType);

            CreatedAnnouncementTypeResponse response = _mapper.Map<CreatedAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}
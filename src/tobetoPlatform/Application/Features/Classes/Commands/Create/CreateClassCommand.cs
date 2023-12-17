using Application.Features.Classes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classes.Commands.Create;

public class CreateClassCommand : IRequest<CreatedClassResponse>
{
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }

    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, CreatedClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly ClassBusinessRules _classBusinessRules;

        public CreateClassCommandHandler(IMapper mapper, IClassRepository classRepository,
                                         ClassBusinessRules classBusinessRules)
        {
            _mapper = mapper;
            _classRepository = classRepository;
            _classBusinessRules = classBusinessRules;
        }

        public async Task<CreatedClassResponse> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            Class class = _mapper.Map<Class>(request);

            await _classRepository.AddAsync(class);

            CreatedClassResponse response = _mapper.Map<CreatedClassResponse>(class);
            return response;
        }
    }
}
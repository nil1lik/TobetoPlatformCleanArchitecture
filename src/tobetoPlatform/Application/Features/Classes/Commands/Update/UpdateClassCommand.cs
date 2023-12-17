using Application.Features.Classes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classes.Commands.Update;

public class UpdateClassCommand : IRequest<UpdatedClassResponse>
{
    public int Id { get; set; }
    public int ProfileAnnouncementId { get; set; }
    public string Name { get; set; }

    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, UpdatedClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly ClassBusinessRules _classBusinessRules;

        public UpdateClassCommandHandler(IMapper mapper, IClassRepository classRepository,
                                         ClassBusinessRules classBusinessRules)
        {
            _mapper = mapper;
            _classRepository = classRepository;
            _classBusinessRules = classBusinessRules;
        }

        public async Task<UpdatedClassResponse> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            Class? class = await _classRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classBusinessRules.ClassShouldExistWhenSelected(class);
            class = _mapper.Map(request, class);

            await _classRepository.UpdateAsync(class!);

            UpdatedClassResponse response = _mapper.Map<UpdatedClassResponse>(class);
            return response;
        }
    }
}
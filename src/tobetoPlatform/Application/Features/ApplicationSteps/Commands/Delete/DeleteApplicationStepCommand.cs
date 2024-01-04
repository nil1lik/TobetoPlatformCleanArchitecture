using Application.Features.ApplicationSteps.Constants;
using Application.Features.ApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationSteps.Commands.Delete;

public class DeleteApplicationStepCommand : IRequest<DeletedApplicationStepResponse>
{
    public int Id { get; set; }

    public class DeleteApplicationStepCommandHandler : IRequestHandler<DeleteApplicationStepCommand, DeletedApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly ApplicationStepBusinessRules _applicationStepBusinessRules;

        public DeleteApplicationStepCommandHandler(IMapper mapper, IApplicationStepRepository applicationStepRepository,
                                         ApplicationStepBusinessRules applicationStepBusinessRules)
        {
            _mapper = mapper;
            _applicationStepRepository = applicationStepRepository;
            _applicationStepBusinessRules = applicationStepBusinessRules;
        }

        public async Task<DeletedApplicationStepResponse> Handle(DeleteApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ApplicationStep? applicationStep = await _applicationStepRepository.GetAsync(predicate: as => as.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationStepBusinessRules.ApplicationStepShouldExistWhenSelected(applicationStep);

            await _applicationStepRepository.DeleteAsync(applicationStep!);

            DeletedApplicationStepResponse response = _mapper.Map<DeletedApplicationStepResponse>(applicationStep);
            return response;
        }
    }
}
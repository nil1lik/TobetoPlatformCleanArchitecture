using Application.Features.ApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationSteps.Commands.Update;

public class UpdateApplicationStepCommand : IRequest<UpdatedApplicationStepResponse>
{
    public int Id { get; set; }
    public int UserApplicationId { get; set; }
    public string Name { get; set; }
    public string? DocumentUrl { get; set; }
    public string? FormUrl { get; set; }

    public class UpdateApplicationStepCommandHandler : IRequestHandler<UpdateApplicationStepCommand, UpdatedApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly ApplicationStepBusinessRules _applicationStepBusinessRules;

        public UpdateApplicationStepCommandHandler(IMapper mapper, IApplicationStepRepository applicationStepRepository,
                                         ApplicationStepBusinessRules applicationStepBusinessRules)
        {
            _mapper = mapper;
            _applicationStepRepository = applicationStepRepository;
            _applicationStepBusinessRules = applicationStepBusinessRules;
        }

        public async Task<UpdatedApplicationStepResponse> Handle(UpdateApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ApplicationStep? applicationStep = await _applicationStepRepository.GetAsync(predicate: aps => aps.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationStepBusinessRules.ApplicationStepShouldExistWhenSelected(applicationStep);
            applicationStep = _mapper.Map(request, applicationStep);

            await _applicationStepRepository.UpdateAsync(applicationStep!);

            UpdatedApplicationStepResponse response = _mapper.Map<UpdatedApplicationStepResponse>(applicationStep);
            return response;
        }
    }
}
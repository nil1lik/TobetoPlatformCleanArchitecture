using Application.Features.ApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationSteps.Commands.Create;

public class CreateApplicationStepCommand : IRequest<CreatedApplicationStepResponse>
{
    public int UserApplicationId { get; set; }
    public string Name { get; set; }
    public string? DocumentUrl { get; set; }
    public string? FormUrl { get; set; }

    public class CreateApplicationStepCommandHandler : IRequestHandler<CreateApplicationStepCommand, CreatedApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly ApplicationStepBusinessRules _applicationStepBusinessRules;

        public CreateApplicationStepCommandHandler(IMapper mapper, IApplicationStepRepository applicationStepRepository,
                                         ApplicationStepBusinessRules applicationStepBusinessRules)
        {
            _mapper = mapper;
            _applicationStepRepository = applicationStepRepository;
            _applicationStepBusinessRules = applicationStepBusinessRules;
        }

        public async Task<CreatedApplicationStepResponse> Handle(CreateApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ApplicationStep applicationStep = _mapper.Map<ApplicationStep>(request);

            await _applicationStepRepository.AddAsync(applicationStep);

            CreatedApplicationStepResponse response = _mapper.Map<CreatedApplicationStepResponse>(applicationStep);
            return response;
        }
    }
}
using Application.Features.ProfileApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationSteps.Commands.Create;

public class CreateProfileApplicationStepCommand : IRequest<CreatedProfileApplicationStepResponse>
{
    public int ApplicationStepId { get; set; }
    public int ProfileApplicationId { get; set; }
    public bool IsCompleted { get; set; }

    public class CreateProfileApplicationStepCommandHandler : IRequestHandler<CreateProfileApplicationStepCommand, CreatedProfileApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
        private readonly ProfileApplicationStepBusinessRules _profileApplicationStepBusinessRules;

        public CreateProfileApplicationStepCommandHandler(IMapper mapper, IProfileApplicationStepRepository profileApplicationStepRepository,
                                         ProfileApplicationStepBusinessRules profileApplicationStepBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationStepRepository = profileApplicationStepRepository;
            _profileApplicationStepBusinessRules = profileApplicationStepBusinessRules;
        }

        public async Task<CreatedProfileApplicationStepResponse> Handle(CreateProfileApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationStep profileApplicationStep = _mapper.Map<ProfileApplicationStep>(request);

            await _profileApplicationStepRepository.AddAsync(profileApplicationStep);

            CreatedProfileApplicationStepResponse response = _mapper.Map<CreatedProfileApplicationStepResponse>(profileApplicationStep);
            return response;
        }
    }
}
using Application.Features.ProfileApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationSteps.Commands.Update;

public class UpdateProfileApplicationStepCommand : IRequest<UpdatedProfileApplicationStepResponse>
{
    public int Id { get; set; }
    public int ApplicationStepId { get; set; }
    public int ProfileApplicationId { get; set; }
    public bool IsCompleted { get; set; }

    public class UpdateProfileApplicationStepCommandHandler : IRequestHandler<UpdateProfileApplicationStepCommand, UpdatedProfileApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
        private readonly ProfileApplicationStepBusinessRules _profileApplicationStepBusinessRules;

        public UpdateProfileApplicationStepCommandHandler(IMapper mapper, IProfileApplicationStepRepository profileApplicationStepRepository,
                                         ProfileApplicationStepBusinessRules profileApplicationStepBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationStepRepository = profileApplicationStepRepository;
            _profileApplicationStepBusinessRules = profileApplicationStepBusinessRules;
        }

        public async Task<UpdatedProfileApplicationStepResponse> Handle(UpdateProfileApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationStep? profileApplicationStep = await _profileApplicationStepRepository.GetAsync(predicate: pas => pas.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationStepBusinessRules.ProfileApplicationStepShouldExistWhenSelected(profileApplicationStep);
            profileApplicationStep = _mapper.Map(request, profileApplicationStep);

            await _profileApplicationStepRepository.UpdateAsync(profileApplicationStep!);

            UpdatedProfileApplicationStepResponse response = _mapper.Map<UpdatedProfileApplicationStepResponse>(profileApplicationStep);
            return response;
        }
    }
}
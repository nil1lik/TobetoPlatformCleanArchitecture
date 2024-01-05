using Application.Features.ProfileApplicationSteps.Constants;
using Application.Features.ProfileApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationSteps.Commands.Delete;

public class DeleteProfileApplicationStepCommand : IRequest<DeletedProfileApplicationStepResponse>
{
    public int Id { get; set; }

    public class DeleteProfileApplicationStepCommandHandler : IRequestHandler<DeleteProfileApplicationStepCommand, DeletedProfileApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
        private readonly ProfileApplicationStepBusinessRules _profileApplicationStepBusinessRules;

        public DeleteProfileApplicationStepCommandHandler(IMapper mapper, IProfileApplicationStepRepository profileApplicationStepRepository,
                                         ProfileApplicationStepBusinessRules profileApplicationStepBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationStepRepository = profileApplicationStepRepository;
            _profileApplicationStepBusinessRules = profileApplicationStepBusinessRules;
        }

        public async Task<DeletedProfileApplicationStepResponse> Handle(DeleteProfileApplicationStepCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationStep? profileApplicationStep = await _profileApplicationStepRepository.GetAsync(predicate: pas => pas.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationStepBusinessRules.ProfileApplicationStepShouldExistWhenSelected(profileApplicationStep);

            await _profileApplicationStepRepository.DeleteAsync(profileApplicationStep!);

            DeletedProfileApplicationStepResponse response = _mapper.Map<DeletedProfileApplicationStepResponse>(profileApplicationStep);
            return response;
        }
    }
}
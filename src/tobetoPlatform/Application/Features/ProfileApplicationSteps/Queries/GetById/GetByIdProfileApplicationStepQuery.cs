using Application.Features.ProfileApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationSteps.Queries.GetById;

public class GetByIdProfileApplicationStepQuery : IRequest<GetByIdProfileApplicationStepResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileApplicationStepQueryHandler : IRequestHandler<GetByIdProfileApplicationStepQuery, GetByIdProfileApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
        private readonly ProfileApplicationStepBusinessRules _profileApplicationStepBusinessRules;

        public GetByIdProfileApplicationStepQueryHandler(IMapper mapper, IProfileApplicationStepRepository profileApplicationStepRepository, ProfileApplicationStepBusinessRules profileApplicationStepBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationStepRepository = profileApplicationStepRepository;
            _profileApplicationStepBusinessRules = profileApplicationStepBusinessRules;
        }

        public async Task<GetByIdProfileApplicationStepResponse> Handle(GetByIdProfileApplicationStepQuery request, CancellationToken cancellationToken)
        {
            ProfileApplicationStep? profileApplicationStep = await _profileApplicationStepRepository.GetAsync(predicate: pas => pas.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationStepBusinessRules.ProfileApplicationStepShouldExistWhenSelected(profileApplicationStep);

            GetByIdProfileApplicationStepResponse response = _mapper.Map<GetByIdProfileApplicationStepResponse>(profileApplicationStep);
            return response;
        }
    }
}
using Application.Features.ApplicationSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationSteps.Queries.GetById;

public class GetByIdApplicationStepQuery : IRequest<GetByIdApplicationStepResponse>
{
    public int Id { get; set; }

    public class GetByIdApplicationStepQueryHandler : IRequestHandler<GetByIdApplicationStepQuery, GetByIdApplicationStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly ApplicationStepBusinessRules _applicationStepBusinessRules;

        public GetByIdApplicationStepQueryHandler(IMapper mapper, IApplicationStepRepository applicationStepRepository, ApplicationStepBusinessRules applicationStepBusinessRules)
        {
            _mapper = mapper;
            _applicationStepRepository = applicationStepRepository;
            _applicationStepBusinessRules = applicationStepBusinessRules;
        }

        public async Task<GetByIdApplicationStepResponse> Handle(GetByIdApplicationStepQuery request, CancellationToken cancellationToken)
        {
            ApplicationStep? applicationStep = await _applicationStepRepository.GetAsync(predicate: as => as.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationStepBusinessRules.ApplicationStepShouldExistWhenSelected(applicationStep);

            GetByIdApplicationStepResponse response = _mapper.Map<GetByIdApplicationStepResponse>(applicationStep);
            return response;
        }
    }
}
using Application.Features.ApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ApplicationForms.Queries.GetById;

public class GetByIdApplicationFormQuery : IRequest<GetByIdApplicationFormResponse>
{
    public int Id { get; set; }

    public class GetByIdApplicationFormQueryHandler : IRequestHandler<GetByIdApplicationFormQuery, GetByIdApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly ApplicationFormBusinessRules _applicationFormBusinessRules;

        public GetByIdApplicationFormQueryHandler(IMapper mapper, IApplicationFormRepository applicationFormRepository, ApplicationFormBusinessRules applicationFormBusinessRules)
        {
            _mapper = mapper;
            _applicationFormRepository = applicationFormRepository;
            _applicationFormBusinessRules = applicationFormBusinessRules;
        }

        public async Task<GetByIdApplicationFormResponse> Handle(GetByIdApplicationFormQuery request, CancellationToken cancellationToken)
        {
            ApplicationForm? applicationForm = await _applicationFormRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _applicationFormBusinessRules.ApplicationFormShouldExistWhenSelected(applicationForm);

            GetByIdApplicationFormResponse response = _mapper.Map<GetByIdApplicationFormResponse>(applicationForm);
            return response;
        }
    }
}
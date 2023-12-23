using Application.Features.ProfileApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationForms.Queries.GetById;

public class GetByIdProfileApplicationFormQuery : IRequest<GetByIdProfileApplicationFormResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileApplicationFormQueryHandler : IRequestHandler<GetByIdProfileApplicationFormQuery, GetByIdProfileApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
        private readonly ProfileApplicationFormBusinessRules _profileApplicationFormBusinessRules;

        public GetByIdProfileApplicationFormQueryHandler(IMapper mapper, IProfileApplicationFormRepository profileApplicationFormRepository, ProfileApplicationFormBusinessRules profileApplicationFormBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationFormRepository = profileApplicationFormRepository;
            _profileApplicationFormBusinessRules = profileApplicationFormBusinessRules;
        }

        public async Task<GetByIdProfileApplicationFormResponse> Handle(GetByIdProfileApplicationFormQuery request, CancellationToken cancellationToken)
        {
            ProfileApplicationForm? profileApplicationForm = await _profileApplicationFormRepository.GetAsync(predicate: paf => paf.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationFormBusinessRules.ProfileApplicationFormShouldExistWhenSelected(profileApplicationForm);

            GetByIdProfileApplicationFormResponse response = _mapper.Map<GetByIdProfileApplicationFormResponse>(profileApplicationForm);
            return response;
        }
    }
}
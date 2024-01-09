using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Queries.GetById;

public class GetByIdSocialMediaAccountQuery : IRequest<GetByIdSocialMediaAccountResponse>
{
    public int Id { get; set; }

    public class GetByIdSocialMediaAccountQueryHandler : IRequestHandler<GetByIdSocialMediaAccountQuery, GetByIdSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public GetByIdSocialMediaAccountQueryHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository, SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<GetByIdSocialMediaAccountResponse> Handle(GetByIdSocialMediaAccountQuery request, CancellationToken cancellationToken)
        {
            SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaAccountBusinessRules.SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);

            GetByIdSocialMediaAccountResponse response = _mapper.Map<GetByIdSocialMediaAccountResponse>(socialMediaAccount);
            return response;
        }
    }
}
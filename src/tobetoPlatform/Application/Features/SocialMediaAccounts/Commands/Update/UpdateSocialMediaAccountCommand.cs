using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommand : IRequest<UpdatedSocialMediaAccountResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string MediaUrl { get; set; }

    public class UpdateSocialMediaAccountCommandHandler : IRequestHandler<UpdateSocialMediaAccountCommand, UpdatedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public UpdateSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<UpdatedSocialMediaAccountResponse> Handle(UpdateSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaAccountBusinessRules.SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);
            socialMediaAccount = _mapper.Map(request, socialMediaAccount);

            await _socialMediaAccountRepository.UpdateAsync(socialMediaAccount!);

            UpdatedSocialMediaAccountResponse response = _mapper.Map<UpdatedSocialMediaAccountResponse>(socialMediaAccount);
            return response;
        }
    }
}
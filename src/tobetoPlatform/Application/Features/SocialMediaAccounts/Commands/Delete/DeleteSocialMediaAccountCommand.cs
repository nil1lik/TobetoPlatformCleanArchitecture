using Application.Features.SocialMediaAccounts.Constants;
using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Commands.Delete;

public class DeleteSocialMediaAccountCommand : IRequest<DeletedSocialMediaAccountResponse>
{
    public int Id { get; set; }

    public class DeleteSocialMediaAccountCommandHandler : IRequestHandler<DeleteSocialMediaAccountCommand, DeletedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public DeleteSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<DeletedSocialMediaAccountResponse> Handle(DeleteSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            SocialMediaAccount? socialMediaAccount = await _socialMediaAccountRepository.GetAsync(predicate: sma => sma.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaAccountBusinessRules.SocialMediaAccountShouldExistWhenSelected(socialMediaAccount);

            await _socialMediaAccountRepository.DeleteAsync(socialMediaAccount!);

            DeletedSocialMediaAccountResponse response = _mapper.Map<DeletedSocialMediaAccountResponse>(socialMediaAccount);
            response.Message = "Sosyal medya hesabýnýz baþarýyla kaldýrýldý";
            return response;
        }
    }
}
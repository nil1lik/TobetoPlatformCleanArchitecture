using Application.Features.SocialMediaAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommand : IRequest<CreatedSocialMediaAccountResponse>
{
    public int UserProfileId { get; set; }
    public int SocialMediaCategoryId { get; set; }
    public string Name { get; set; }
    public string MediaUrl { get; set; }

    public class CreateSocialMediaAccountCommandHandler : IRequestHandler<CreateSocialMediaAccountCommand, CreatedSocialMediaAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly SocialMediaAccountBusinessRules _socialMediaAccountBusinessRules;

        public CreateSocialMediaAccountCommandHandler(IMapper mapper, ISocialMediaAccountRepository socialMediaAccountRepository,
                                         SocialMediaAccountBusinessRules socialMediaAccountBusinessRules)
        {
            _mapper = mapper;
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _socialMediaAccountBusinessRules = socialMediaAccountBusinessRules;
        }

        public async Task<CreatedSocialMediaAccountResponse> Handle(CreateSocialMediaAccountCommand request, CancellationToken cancellationToken)
        {
            SocialMediaAccount socialMediaAccount = _mapper.Map<SocialMediaAccount>(request);

            await _socialMediaAccountBusinessRules.SocialMediaAccountsShouldNotBeTheSame(request.UserProfileId, socialMediaAccount);
            await _socialMediaAccountBusinessRules.CheckUserSocialMediaAccountLimit(request.UserProfileId);

            await _socialMediaAccountRepository.AddAsync(socialMediaAccount);
            CreatedSocialMediaAccountResponse response = _mapper.Map<CreatedSocialMediaAccountResponse>(socialMediaAccount);
            response.Message = "Sosyal medya adresiniz baþarýyla eklendi";
            return response;
        }

       


    }
}
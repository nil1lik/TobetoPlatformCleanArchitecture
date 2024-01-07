using Application.Features.SocialMediaCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaCategories.Commands.Update;

public class UpdateSocialMediaCategoryCommand : IRequest<UpdatedSocialMediaCategoryResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateSocialMediaCategoryCommandHandler : IRequestHandler<UpdateSocialMediaCategoryCommand, UpdatedSocialMediaCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
        private readonly SocialMediaCategoryBusinessRules _socialMediaCategoryBusinessRules;

        public UpdateSocialMediaCategoryCommandHandler(IMapper mapper, ISocialMediaCategoryRepository socialMediaCategoryRepository,
                                         SocialMediaCategoryBusinessRules socialMediaCategoryBusinessRules)
        {
            _mapper = mapper;
            _socialMediaCategoryRepository = socialMediaCategoryRepository;
            _socialMediaCategoryBusinessRules = socialMediaCategoryBusinessRules;
        }

        public async Task<UpdatedSocialMediaCategoryResponse> Handle(UpdateSocialMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            SocialMediaCategory? socialMediaCategory = await _socialMediaCategoryRepository.GetAsync(predicate: smc => smc.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaCategoryBusinessRules.SocialMediaCategoryShouldExistWhenSelected(socialMediaCategory);
            socialMediaCategory = _mapper.Map(request, socialMediaCategory);

            await _socialMediaCategoryRepository.UpdateAsync(socialMediaCategory!);

            UpdatedSocialMediaCategoryResponse response = _mapper.Map<UpdatedSocialMediaCategoryResponse>(socialMediaCategory);
            return response;
        }
    }
}
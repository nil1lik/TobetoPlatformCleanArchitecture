using Application.Features.SocialMediaCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaCategories.Queries.GetById;

public class GetByIdSocialMediaCategoryQuery : IRequest<GetByIdSocialMediaCategoryResponse>
{
    public int Id { get; set; }

    public class GetByIdSocialMediaCategoryQueryHandler : IRequestHandler<GetByIdSocialMediaCategoryQuery, GetByIdSocialMediaCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
        private readonly SocialMediaCategoryBusinessRules _socialMediaCategoryBusinessRules;

        public GetByIdSocialMediaCategoryQueryHandler(IMapper mapper, ISocialMediaCategoryRepository socialMediaCategoryRepository, SocialMediaCategoryBusinessRules socialMediaCategoryBusinessRules)
        {
            _mapper = mapper;
            _socialMediaCategoryRepository = socialMediaCategoryRepository;
            _socialMediaCategoryBusinessRules = socialMediaCategoryBusinessRules;
        }

        public async Task<GetByIdSocialMediaCategoryResponse> Handle(GetByIdSocialMediaCategoryQuery request, CancellationToken cancellationToken)
        {
            SocialMediaCategory? socialMediaCategory = await _socialMediaCategoryRepository.GetAsync(predicate: smc => smc.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaCategoryBusinessRules.SocialMediaCategoryShouldExistWhenSelected(socialMediaCategory);

            GetByIdSocialMediaCategoryResponse response = _mapper.Map<GetByIdSocialMediaCategoryResponse>(socialMediaCategory);
            return response;
        }
    }
}
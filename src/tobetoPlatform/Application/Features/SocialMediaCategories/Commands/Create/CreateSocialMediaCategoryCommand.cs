using Application.Features.SocialMediaCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaCategories.Commands.Create;

public class CreateSocialMediaCategoryCommand : IRequest<CreatedSocialMediaCategoryResponse>
{
    public string Name { get; set; }

    public class CreateSocialMediaCategoryCommandHandler : IRequestHandler<CreateSocialMediaCategoryCommand, CreatedSocialMediaCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
        private readonly SocialMediaCategoryBusinessRules _socialMediaCategoryBusinessRules;

        public CreateSocialMediaCategoryCommandHandler(IMapper mapper, ISocialMediaCategoryRepository socialMediaCategoryRepository,
                                         SocialMediaCategoryBusinessRules socialMediaCategoryBusinessRules)
        {
            _mapper = mapper;
            _socialMediaCategoryRepository = socialMediaCategoryRepository;
            _socialMediaCategoryBusinessRules = socialMediaCategoryBusinessRules;
        }

        public async Task<CreatedSocialMediaCategoryResponse> Handle(CreateSocialMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            SocialMediaCategory socialMediaCategory = _mapper.Map<SocialMediaCategory>(request);

            await _socialMediaCategoryRepository.AddAsync(socialMediaCategory);

            CreatedSocialMediaCategoryResponse response = _mapper.Map<CreatedSocialMediaCategoryResponse>(socialMediaCategory);
            return response;
        }
    }
}
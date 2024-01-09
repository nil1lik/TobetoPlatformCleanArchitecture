using Application.Features.SocialMediaCategories.Constants;
using Application.Features.SocialMediaCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaCategories.Commands.Delete;

public class DeleteSocialMediaCategoryCommand : IRequest<DeletedSocialMediaCategoryResponse>
{
    public int Id { get; set; }

    public class DeleteSocialMediaCategoryCommandHandler : IRequestHandler<DeleteSocialMediaCategoryCommand, DeletedSocialMediaCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
        private readonly SocialMediaCategoryBusinessRules _socialMediaCategoryBusinessRules;

        public DeleteSocialMediaCategoryCommandHandler(IMapper mapper, ISocialMediaCategoryRepository socialMediaCategoryRepository,
                                         SocialMediaCategoryBusinessRules socialMediaCategoryBusinessRules)
        {
            _mapper = mapper;
            _socialMediaCategoryRepository = socialMediaCategoryRepository;
            _socialMediaCategoryBusinessRules = socialMediaCategoryBusinessRules;
        }

        public async Task<DeletedSocialMediaCategoryResponse> Handle(DeleteSocialMediaCategoryCommand request, CancellationToken cancellationToken)
        {
            SocialMediaCategory? socialMediaCategory = await _socialMediaCategoryRepository.GetAsync(predicate: smc => smc.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaCategoryBusinessRules.SocialMediaCategoryShouldExistWhenSelected(socialMediaCategory);

            await _socialMediaCategoryRepository.DeleteAsync(socialMediaCategory!);

            DeletedSocialMediaCategoryResponse response = _mapper.Map<DeletedSocialMediaCategoryResponse>(socialMediaCategory);
            return response;
        }
    }
}
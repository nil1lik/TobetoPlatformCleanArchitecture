using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SocialMediaCategories.Queries.GetList;

public class GetListSocialMediaCategoryQuery : IRequest<GetListResponse<GetListSocialMediaCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSocialMediaCategoryQueryHandler : IRequestHandler<GetListSocialMediaCategoryQuery, GetListResponse<GetListSocialMediaCategoryListItemDto>>
    {
        private readonly ISocialMediaCategoryRepository _socialMediaCategoryRepository;
        private readonly IMapper _mapper;

        public GetListSocialMediaCategoryQueryHandler(ISocialMediaCategoryRepository socialMediaCategoryRepository, IMapper mapper)
        {
            _socialMediaCategoryRepository = socialMediaCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialMediaCategoryListItemDto>> Handle(GetListSocialMediaCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialMediaCategory> socialMediaCategories = await _socialMediaCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialMediaCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListSocialMediaCategoryListItemDto>>(socialMediaCategories);
            return response;
        }
    }
}
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountQuery : IRequest<GetListResponse<GetListSocialMediaAccountListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSocialMediaAccountQueryHandler : IRequestHandler<GetListSocialMediaAccountQuery, GetListResponse<GetListSocialMediaAccountListItemDto>>
    {
        private readonly ISocialMediaAccountRepository _socialMediaAccountRepository;
        private readonly IMapper _mapper;

        public GetListSocialMediaAccountQueryHandler(ISocialMediaAccountRepository socialMediaAccountRepository, IMapper mapper)
        {
            _socialMediaAccountRepository = socialMediaAccountRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialMediaAccountListItemDto>> Handle(GetListSocialMediaAccountQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialMediaAccount> socialMediaAccounts = await _socialMediaAccountRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialMediaAccountListItemDto> response = _mapper.Map<GetListResponse<GetListSocialMediaAccountListItemDto>>(socialMediaAccounts);
            return response;
        }
    }
}
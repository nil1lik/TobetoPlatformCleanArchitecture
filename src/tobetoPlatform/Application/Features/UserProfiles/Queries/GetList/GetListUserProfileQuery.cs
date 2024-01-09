using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserProfiles.Queries.GetList;

public class GetListUserProfileQuery : IRequest<GetListResponse<GetListUserProfileListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserProfileQueryHandler : IRequestHandler<GetListUserProfileQuery, GetListResponse<GetListUserProfileListItemDto>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public GetListUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserProfileListItemDto>> Handle(GetListUserProfileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserProfile> userProfiles = await _userProfileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserProfileListItemDto> response = _mapper.Map<GetListResponse<GetListUserProfileListItemDto>>(userProfiles);
            return response;
        }
    }
}
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileShares.Queries.GetList;

public class GetListProfileShareQuery : IRequest<GetListResponse<GetListProfileShareListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileShareQueryHandler : IRequestHandler<GetListProfileShareQuery, GetListResponse<GetListProfileShareListItemDto>>
    {
        private readonly IProfileShareRepository _profileShareRepository;
        private readonly IMapper _mapper;

        public GetListProfileShareQueryHandler(IProfileShareRepository profileShareRepository, IMapper mapper)
        {
            _profileShareRepository = profileShareRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileShareListItemDto>> Handle(GetListProfileShareQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileShare> profileShares = await _profileShareRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileShareListItemDto> response = _mapper.Map<GetListResponse<GetListProfileShareListItemDto>>(profileShares);
            return response;
        }
    }
}
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileAddresses.Queries.GetList;

public class GetListProfileAddressQuery : IRequest<GetListResponse<GetListProfileAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileAddressQueryHandler : IRequestHandler<GetListProfileAddressQuery, GetListResponse<GetListProfileAddressListItemDto>>
    {
        private readonly IProfileAddressRepository _profileAddressRepository;
        private readonly IMapper _mapper;

        public GetListProfileAddressQueryHandler(IProfileAddressRepository profileAddressRepository, IMapper mapper)
        {
            _profileAddressRepository = profileAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileAddressListItemDto>> Handle(GetListProfileAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileAddress> profileAddresses = await _profileAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileAddressListItemDto> response = _mapper.Map<GetListResponse<GetListProfileAddressListItemDto>>(profileAddresses);
            return response;
        }
    }
}
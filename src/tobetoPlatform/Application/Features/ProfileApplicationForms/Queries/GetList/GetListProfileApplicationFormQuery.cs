using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileApplicationForms.Queries.GetList;

public class GetListProfileApplicationFormQuery : IRequest<GetListResponse<GetListProfileApplicationFormListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileApplicationFormQueryHandler : IRequestHandler<GetListProfileApplicationFormQuery, GetListResponse<GetListProfileApplicationFormListItemDto>>
    {
        private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
        private readonly IMapper _mapper;

        public GetListProfileApplicationFormQueryHandler(IProfileApplicationFormRepository profileApplicationFormRepository, IMapper mapper)
        {
            _profileApplicationFormRepository = profileApplicationFormRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileApplicationFormListItemDto>> Handle(GetListProfileApplicationFormQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileApplicationForm> profileApplicationForms = await _profileApplicationFormRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileApplicationFormListItemDto> response = _mapper.Map<GetListResponse<GetListProfileApplicationFormListItemDto>>(profileApplicationForms);
            return response;
        }
    }
}
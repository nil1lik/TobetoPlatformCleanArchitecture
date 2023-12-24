using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileApplications.Queries.GetList;

public class GetListProfileApplicationQuery : IRequest<GetListResponse<GetListProfileApplicationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileApplicationQueryHandler : IRequestHandler<GetListProfileApplicationQuery, GetListResponse<GetListProfileApplicationListItemDto>>
    {
        private readonly IProfileApplicationRepository _profileApplicationRepository;
        private readonly IMapper _mapper;

        public GetListProfileApplicationQueryHandler(IProfileApplicationRepository profileApplicationRepository, IMapper mapper)
        {
            _profileApplicationRepository = profileApplicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileApplicationListItemDto>> Handle(GetListProfileApplicationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileApplication> profileApplications = await _profileApplicationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileApplicationListItemDto> response = _mapper.Map<GetListResponse<GetListProfileApplicationListItemDto>>(profileApplications);
            return response;
        }
    }
}
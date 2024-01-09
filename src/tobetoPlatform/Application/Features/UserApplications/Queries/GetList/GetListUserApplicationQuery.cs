using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserApplications.Queries.GetList;

public class GetListUserApplicationQuery : IRequest<GetListResponse<GetListUserApplicationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserApplicationQueryHandler : IRequestHandler<GetListUserApplicationQuery, GetListResponse<GetListUserApplicationListItemDto>>
    {
        private readonly IUserApplicationRepository _userApplicationRepository;
        private readonly IMapper _mapper;

        public GetListUserApplicationQueryHandler(IUserApplicationRepository userApplicationRepository, IMapper mapper)
        {
            _userApplicationRepository = userApplicationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserApplicationListItemDto>> Handle(GetListUserApplicationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserApplication> userApplications = await _userApplicationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserApplicationListItemDto> response = _mapper.Map<GetListResponse<GetListUserApplicationListItemDto>>(userApplications);
            return response;
        }
    }
}
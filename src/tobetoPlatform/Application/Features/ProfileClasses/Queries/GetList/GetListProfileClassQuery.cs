using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileClasses.Queries.GetList;

public class GetListProfileClassQuery : IRequest<GetListResponse<GetListProfileClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileClassQueryHandler : IRequestHandler<GetListProfileClassQuery, GetListResponse<GetListProfileClassListItemDto>>
    {
        private readonly IProfileClassRepository _profileClassRepository;
        private readonly IMapper _mapper;

        public GetListProfileClassQueryHandler(IProfileClassRepository profileClassRepository, IMapper mapper)
        {
            _profileClassRepository = profileClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileClassListItemDto>> Handle(GetListProfileClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileClass> profileClasses = await _profileClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileClassListItemDto> response = _mapper.Map<GetListResponse<GetListProfileClassListItemDto>>(profileClasses);
            return response;
        }
    }
}
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileAdmirations.Queries.GetList;

public class GetListProfileAdmirationQuery : IRequest<GetListResponse<GetListProfileAdmirationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileAdmirationQueryHandler : IRequestHandler<GetListProfileAdmirationQuery, GetListResponse<GetListProfileAdmirationListItemDto>>
    {
        private readonly IProfileAdmirationRepository _profileAdmirationRepository;
        private readonly IMapper _mapper;

        public GetListProfileAdmirationQueryHandler(IProfileAdmirationRepository profileAdmirationRepository, IMapper mapper)
        {
            _profileAdmirationRepository = profileAdmirationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileAdmirationListItemDto>> Handle(GetListProfileAdmirationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileAdmiration> profileAdmirations = await _profileAdmirationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileAdmirationListItemDto> response = _mapper.Map<GetListResponse<GetListProfileAdmirationListItemDto>>(profileAdmirations);
            return response;
        }
    }
}
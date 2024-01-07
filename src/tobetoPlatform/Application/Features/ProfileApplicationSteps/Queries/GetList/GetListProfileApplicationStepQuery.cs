using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ProfileApplicationSteps.Queries.GetList;

public class GetListProfileApplicationStepQuery : IRequest<GetListResponse<GetListProfileApplicationStepListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProfileApplicationStepQueryHandler : IRequestHandler<GetListProfileApplicationStepQuery, GetListResponse<GetListProfileApplicationStepListItemDto>>
    {
        private readonly IProfileApplicationStepRepository _profileApplicationStepRepository;
        private readonly IMapper _mapper;

        public GetListProfileApplicationStepQueryHandler(IProfileApplicationStepRepository profileApplicationStepRepository, IMapper mapper)
        {
            _profileApplicationStepRepository = profileApplicationStepRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProfileApplicationStepListItemDto>> Handle(GetListProfileApplicationStepQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProfileApplicationStep> profileApplicationSteps = await _profileApplicationStepRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProfileApplicationStepListItemDto> response = _mapper.Map<GetListResponse<GetListProfileApplicationStepListItemDto>>(profileApplicationSteps);
            return response;
        }
    }
}
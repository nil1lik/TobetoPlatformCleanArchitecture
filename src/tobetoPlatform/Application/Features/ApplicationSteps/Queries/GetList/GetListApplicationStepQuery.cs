using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ApplicationSteps.Queries.GetList;

public class GetListApplicationStepQuery : IRequest<GetListResponse<GetListApplicationStepListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListApplicationStepQueryHandler : IRequestHandler<GetListApplicationStepQuery, GetListResponse<GetListApplicationStepListItemDto>>
    {
        private readonly IApplicationStepRepository _applicationStepRepository;
        private readonly IMapper _mapper;

        public GetListApplicationStepQueryHandler(IApplicationStepRepository applicationStepRepository, IMapper mapper)
        {
            _applicationStepRepository = applicationStepRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationStepListItemDto>> Handle(GetListApplicationStepQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ApplicationStep> applicationSteps = await _applicationStepRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationStepListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationStepListItemDto>>(applicationSteps);
            return response;
        }
    }
}
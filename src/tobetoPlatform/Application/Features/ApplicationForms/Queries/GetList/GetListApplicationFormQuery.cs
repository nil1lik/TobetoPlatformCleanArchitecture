using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ApplicationForms.Queries.GetList;

public class GetListApplicationFormQuery : IRequest<GetListResponse<GetListApplicationFormListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListApplicationFormQueryHandler : IRequestHandler<GetListApplicationFormQuery, GetListResponse<GetListApplicationFormListItemDto>>
    {
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly IMapper _mapper;

        public GetListApplicationFormQueryHandler(IApplicationFormRepository applicationFormRepository, IMapper mapper)
        {
            _applicationFormRepository = applicationFormRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationFormListItemDto>> Handle(GetListApplicationFormQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ApplicationForm> applicationForms = await _applicationFormRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationFormListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationFormListItemDto>>(applicationForms);
            return response;
        }
    }
}
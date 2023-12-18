using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Certificates.Queries.GetList;

public class GetListCertificateQuery : IRequest<GetListResponse<GetListCertificateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCertificateQueryHandler : IRequestHandler<GetListCertificateQuery, GetListResponse<GetListCertificateListItemDto>>
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public GetListCertificateQueryHandler(ICertificateRepository certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCertificateListItemDto>> Handle(GetListCertificateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Certificate> certificates = await _certificateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCertificateListItemDto> response = _mapper.Map<GetListResponse<GetListCertificateListItemDto>>(certificates);
            return response;
        }
    }
}
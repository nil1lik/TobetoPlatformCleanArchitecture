using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CatalogPaths.Queries.GetList;

public class GetListCatalogPathQuery : IRequest<GetListResponse<GetListCatalogPathListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCatalogPathQueryHandler : IRequestHandler<GetListCatalogPathQuery, GetListResponse<GetListCatalogPathListItemDto>>
    {
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly IMapper _mapper;

        public GetListCatalogPathQueryHandler(ICatalogPathRepository catalogPathRepository, IMapper mapper)
        {
            _catalogPathRepository = catalogPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCatalogPathListItemDto>> Handle(GetListCatalogPathQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogPath> catalogPaths = await _catalogPathRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCatalogPathListItemDto> response = _mapper.Map<GetListResponse<GetListCatalogPathListItemDto>>(catalogPaths);
            return response;
        }
    }
}
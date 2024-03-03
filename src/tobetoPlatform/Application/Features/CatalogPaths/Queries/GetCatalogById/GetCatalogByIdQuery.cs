using Application.Features.CatalogPaths.Queries.GetById;
using Application.Features.CatalogPaths.Queries.GetList;
using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CatalogPaths.Queries.GetCatalogById;
public class GetCatalogByIdQuery : IRequest<GetListResponse<GetCatalogByIdResponse>>
{
    public PageRequest PageRequest { get; set; }

    public class GetCatalogByIdQueryHandler : IRequestHandler<GetCatalogByIdQuery, GetListResponse<GetCatalogByIdResponse>>
    {
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly IMapper _mapper;

        public GetCatalogByIdQueryHandler(ICatalogPathRepository catalogPathRepository, IMapper mapper)
        {
            _catalogPathRepository = catalogPathRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetCatalogByIdResponse>> Handle(GetCatalogByIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CatalogPath> catalogPaths = await _catalogPathRepository.GetListAsync(
                include: x=>x.Include(x=>x.Instructor),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetCatalogByIdResponse> response = _mapper.Map<GetListResponse<GetCatalogByIdResponse>>(catalogPaths);
            return response;
        }
    }
}

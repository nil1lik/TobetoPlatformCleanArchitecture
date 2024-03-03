using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CatalogPaths.Queries.GetById;

public class GetByIdCatalogPathQuery : IRequest<GetByIdCatalogPathResponse>
{
    public int Id { get; set; }

    public class GetByIdCatalogPathQueryHandler : IRequestHandler<GetByIdCatalogPathQuery, GetByIdCatalogPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly CatalogPathBusinessRules _catalogPathBusinessRules;

        public GetByIdCatalogPathQueryHandler(IMapper mapper, ICatalogPathRepository catalogPathRepository, CatalogPathBusinessRules catalogPathBusinessRules)
        {
            _mapper = mapper;
            _catalogPathRepository = catalogPathRepository;
            _catalogPathBusinessRules = catalogPathBusinessRules;
        }

        public async Task<GetByIdCatalogPathResponse> Handle(GetByIdCatalogPathQuery request, CancellationToken cancellationToken)
        {
            CatalogPath? catalogPath = await _catalogPathRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogPathBusinessRules.CatalogPathShouldExistWhenSelected(catalogPath);

            GetByIdCatalogPathResponse response = _mapper.Map<GetByIdCatalogPathResponse>(catalogPath);
            return response;
        }
    }
}
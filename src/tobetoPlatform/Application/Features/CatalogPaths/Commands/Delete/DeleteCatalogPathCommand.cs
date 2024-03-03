using Application.Features.CatalogPaths.Constants;
using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CatalogPaths.Commands.Delete;

public class DeleteCatalogPathCommand : IRequest<DeletedCatalogPathResponse>
{
    public int Id { get; set; }

    public class DeleteCatalogPathCommandHandler : IRequestHandler<DeleteCatalogPathCommand, DeletedCatalogPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly CatalogPathBusinessRules _catalogPathBusinessRules;

        public DeleteCatalogPathCommandHandler(IMapper mapper, ICatalogPathRepository catalogPathRepository,
                                         CatalogPathBusinessRules catalogPathBusinessRules)
        {
            _mapper = mapper;
            _catalogPathRepository = catalogPathRepository;
            _catalogPathBusinessRules = catalogPathBusinessRules;
        }

        public async Task<DeletedCatalogPathResponse> Handle(DeleteCatalogPathCommand request, CancellationToken cancellationToken)
        {
            CatalogPath? catalogPath = await _catalogPathRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogPathBusinessRules.CatalogPathShouldExistWhenSelected(catalogPath);

            await _catalogPathRepository.DeleteAsync(catalogPath!);

            DeletedCatalogPathResponse response = _mapper.Map<DeletedCatalogPathResponse>(catalogPath);
            return response;
        }
    }
}
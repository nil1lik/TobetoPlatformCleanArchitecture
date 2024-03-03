using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CatalogPaths.Commands.Create;

public class CreateCatalogPathCommand : IRequest<CreatedCatalogPathResponse>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int InstructorId { get; set; }
    public int Time { get; set; }

    public class CreateCatalogPathCommandHandler : IRequestHandler<CreateCatalogPathCommand, CreatedCatalogPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly CatalogPathBusinessRules _catalogPathBusinessRules;

        public CreateCatalogPathCommandHandler(IMapper mapper, ICatalogPathRepository catalogPathRepository,
                                         CatalogPathBusinessRules catalogPathBusinessRules)
        {
            _mapper = mapper;
            _catalogPathRepository = catalogPathRepository;
            _catalogPathBusinessRules = catalogPathBusinessRules;
        }

        public async Task<CreatedCatalogPathResponse> Handle(CreateCatalogPathCommand request, CancellationToken cancellationToken)
        {
            CatalogPath catalogPath = _mapper.Map<CatalogPath>(request);

            await _catalogPathRepository.AddAsync(catalogPath);

            CreatedCatalogPathResponse response = _mapper.Map<CreatedCatalogPathResponse>(catalogPath);
            return response;
        }
    }
}
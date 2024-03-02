using Application.Features.CatalogPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CatalogPaths.Commands.Update;

public class UpdateCatalogPathCommand : IRequest<UpdatedCatalogPathResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int InstructorId { get; set; }
    public DateTime AddedDate { get; set; }

    public class UpdateCatalogPathCommandHandler : IRequestHandler<UpdateCatalogPathCommand, UpdatedCatalogPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogPathRepository _catalogPathRepository;
        private readonly CatalogPathBusinessRules _catalogPathBusinessRules;

        public UpdateCatalogPathCommandHandler(IMapper mapper, ICatalogPathRepository catalogPathRepository,
                                         CatalogPathBusinessRules catalogPathBusinessRules)
        {
            _mapper = mapper;
            _catalogPathRepository = catalogPathRepository;
            _catalogPathBusinessRules = catalogPathBusinessRules;
        }

        public async Task<UpdatedCatalogPathResponse> Handle(UpdateCatalogPathCommand request, CancellationToken cancellationToken)
        {
            CatalogPath? catalogPath = await _catalogPathRepository.GetAsync(predicate: cp => cp.Id == request.Id, cancellationToken: cancellationToken);
            await _catalogPathBusinessRules.CatalogPathShouldExistWhenSelected(catalogPath);
            catalogPath = _mapper.Map(request, catalogPath);

            await _catalogPathRepository.UpdateAsync(catalogPath!);

            UpdatedCatalogPathResponse response = _mapper.Map<UpdatedCatalogPathResponse>(catalogPath);
            return response;
        }
    }
}
using Application.Features.Classes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classes.Queries.GetById;

public class GetByIdClassQuery : IRequest<GetByIdClassResponse>
{
    public int Id { get; set; }

    public class GetByIdClassQueryHandler : IRequestHandler<GetByIdClassQuery, GetByIdClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;
        private readonly ClassBusinessRules _classBusinessRules;

        public GetByIdClassQueryHandler(IMapper mapper, IClassRepository classRepository, ClassBusinessRules classBusinessRules)
        {
            _mapper = mapper;
            _classRepository = classRepository;
            _classBusinessRules = classBusinessRules;
        }

        public async Task<GetByIdClassResponse> Handle(GetByIdClassQuery request, CancellationToken cancellationToken)
        {
            Class? class = await _classRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classBusinessRules.ClassShouldExistWhenSelected(class);

            GetByIdClassResponse response = _mapper.Map<GetByIdClassResponse>(class);
            return response;
        }
    }
}
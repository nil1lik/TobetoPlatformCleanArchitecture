using Application.Features.EducationPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EducationPaths.Queries.GetById;

public class GetByIdEducationPathQuery : IRequest<GetByIdEducationPathResponse>
{
    public int Id { get; set; }

    public class GetByIdEducationPathQueryHandler : IRequestHandler<GetByIdEducationPathQuery, GetByIdEducationPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationPathRepository _educationPathRepository;
        private readonly EducationPathBusinessRules _educationPathBusinessRules;

        public GetByIdEducationPathQueryHandler(IMapper mapper, IEducationPathRepository educationPathRepository, EducationPathBusinessRules educationPathBusinessRules)
        {
            _mapper = mapper;
            _educationPathRepository = educationPathRepository;
            _educationPathBusinessRules = educationPathBusinessRules;
        }

        public async Task<GetByIdEducationPathResponse> Handle(GetByIdEducationPathQuery request, CancellationToken cancellationToken)
        {
            EducationPath? educationPath = await _educationPathRepository.GetAsync(predicate: ep => ep.Id == request.Id, cancellationToken: cancellationToken);
            await _educationPathBusinessRules.EducationPathShouldExistWhenSelected(educationPath);

            GetByIdEducationPathResponse response = _mapper.Map<GetByIdEducationPathResponse>(educationPath);
            return response;
        }
    }
}
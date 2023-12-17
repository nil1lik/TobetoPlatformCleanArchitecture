using Application.Features.Graduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Graduations.Queries.GetById;

public class GetByIdGraduationQuery : IRequest<GetByIdGraduationResponse>
{
    public int Id { get; set; }

    public class GetByIdGraduationQueryHandler : IRequestHandler<GetByIdGraduationQuery, GetByIdGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGraduationRepository _graduationRepository;
        private readonly GraduationBusinessRules _graduationBusinessRules;

        public GetByIdGraduationQueryHandler(IMapper mapper, IGraduationRepository graduationRepository, GraduationBusinessRules graduationBusinessRules)
        {
            _mapper = mapper;
            _graduationRepository = graduationRepository;
            _graduationBusinessRules = graduationBusinessRules;
        }

        public async Task<GetByIdGraduationResponse> Handle(GetByIdGraduationQuery request, CancellationToken cancellationToken)
        {
            Graduation? graduation = await _graduationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _graduationBusinessRules.GraduationShouldExistWhenSelected(graduation);

            GetByIdGraduationResponse response = _mapper.Map<GetByIdGraduationResponse>(graduation);
            return response;
        }
    }
}
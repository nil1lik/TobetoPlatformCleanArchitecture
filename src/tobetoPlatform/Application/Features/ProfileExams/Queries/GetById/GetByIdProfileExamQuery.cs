using Application.Features.ProfileExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileExams.Queries.GetById;

public class GetByIdProfileExamQuery : IRequest<GetByIdProfileExamResponse>
{
    public int Id { get; set; }

    public class GetByIdProfileExamQueryHandler : IRequestHandler<GetByIdProfileExamQuery, GetByIdProfileExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileExamRepository _profileExamRepository;
        private readonly ProfileExamBusinessRules _profileExamBusinessRules;

        public GetByIdProfileExamQueryHandler(IMapper mapper, IProfileExamRepository profileExamRepository, ProfileExamBusinessRules profileExamBusinessRules)
        {
            _mapper = mapper;
            _profileExamRepository = profileExamRepository;
            _profileExamBusinessRules = profileExamBusinessRules;
        }

        public async Task<GetByIdProfileExamResponse> Handle(GetByIdProfileExamQuery request, CancellationToken cancellationToken)
        {
            ProfileExam? profileExam = await _profileExamRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileExamBusinessRules.ProfileExamShouldExistWhenSelected(profileExam);

            GetByIdProfileExamResponse response = _mapper.Map<GetByIdProfileExamResponse>(profileExam);
            return response;
        }
    }
}
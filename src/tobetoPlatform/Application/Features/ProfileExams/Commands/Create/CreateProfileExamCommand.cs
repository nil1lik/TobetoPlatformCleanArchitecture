using Application.Features.ProfileExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileExams.Commands.Create;

public class CreateProfileExamCommand : IRequest<CreatedProfileExamResponse>
{
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }

    public class CreateProfileExamCommandHandler : IRequestHandler<CreateProfileExamCommand, CreatedProfileExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileExamRepository _profileExamRepository;
        private readonly ProfileExamBusinessRules _profileExamBusinessRules;

        public CreateProfileExamCommandHandler(IMapper mapper, IProfileExamRepository profileExamRepository,
                                         ProfileExamBusinessRules profileExamBusinessRules)
        {
            _mapper = mapper;
            _profileExamRepository = profileExamRepository;
            _profileExamBusinessRules = profileExamBusinessRules;
        }

        public async Task<CreatedProfileExamResponse> Handle(CreateProfileExamCommand request, CancellationToken cancellationToken)
        {
            ProfileExam profileExam = _mapper.Map<ProfileExam>(request);

            await _profileExamRepository.AddAsync(profileExam);

            CreatedProfileExamResponse response = _mapper.Map<CreatedProfileExamResponse>(profileExam);
            return response;
        }
    }
}
using Application.Features.ProfileExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileExams.Commands.Update;

public class UpdateProfileExamCommand : IRequest<UpdatedProfileExamResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ExamId { get; set; }

    public class UpdateProfileExamCommandHandler : IRequestHandler<UpdateProfileExamCommand, UpdatedProfileExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileExamRepository _profileExamRepository;
        private readonly ProfileExamBusinessRules _profileExamBusinessRules;

        public UpdateProfileExamCommandHandler(IMapper mapper, IProfileExamRepository profileExamRepository,
                                         ProfileExamBusinessRules profileExamBusinessRules)
        {
            _mapper = mapper;
            _profileExamRepository = profileExamRepository;
            _profileExamBusinessRules = profileExamBusinessRules;
        }

        public async Task<UpdatedProfileExamResponse> Handle(UpdateProfileExamCommand request, CancellationToken cancellationToken)
        {
            ProfileExam? profileExam = await _profileExamRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileExamBusinessRules.ProfileExamShouldExistWhenSelected(profileExam);
            profileExam = _mapper.Map(request, profileExam);

            await _profileExamRepository.UpdateAsync(profileExam!);

            UpdatedProfileExamResponse response = _mapper.Map<UpdatedProfileExamResponse>(profileExam);
            return response;
        }
    }
}
using Application.Features.ProfileExams.Constants;
using Application.Features.ProfileExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileExams.Commands.Delete;

public class DeleteProfileExamCommand : IRequest<DeletedProfileExamResponse>
{
    public int Id { get; set; }

    public class DeleteProfileExamCommandHandler : IRequestHandler<DeleteProfileExamCommand, DeletedProfileExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileExamRepository _profileExamRepository;
        private readonly ProfileExamBusinessRules _profileExamBusinessRules;

        public DeleteProfileExamCommandHandler(IMapper mapper, IProfileExamRepository profileExamRepository,
                                         ProfileExamBusinessRules profileExamBusinessRules)
        {
            _mapper = mapper;
            _profileExamRepository = profileExamRepository;
            _profileExamBusinessRules = profileExamBusinessRules;
        }

        public async Task<DeletedProfileExamResponse> Handle(DeleteProfileExamCommand request, CancellationToken cancellationToken)
        {
            ProfileExam? profileExam = await _profileExamRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileExamBusinessRules.ProfileExamShouldExistWhenSelected(profileExam);

            await _profileExamRepository.DeleteAsync(profileExam!);

            DeletedProfileExamResponse response = _mapper.Map<DeletedProfileExamResponse>(profileExam);
            return response;
        }
    }
}
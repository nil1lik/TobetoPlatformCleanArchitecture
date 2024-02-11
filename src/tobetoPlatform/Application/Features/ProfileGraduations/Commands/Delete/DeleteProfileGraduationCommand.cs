using Application.Features.ProfileGraduations.Constants;
using Application.Features.ProfileGraduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileGraduations.Commands.Delete;

public class DeleteProfileGraduationCommand : IRequest<DeletedProfileGraduationResponse>
{
    public int Id { get; set; }

    public class DeleteProfileGraduationCommandHandler : IRequestHandler<DeleteProfileGraduationCommand, DeletedProfileGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly ProfileGraduationBusinessRules _profileGraduationBusinessRules;

        public DeleteProfileGraduationCommandHandler(IMapper mapper, IProfileGraduationRepository profileGraduationRepository,
                                         ProfileGraduationBusinessRules profileGraduationBusinessRules)
        {
            _mapper = mapper;
            _profileGraduationRepository = profileGraduationRepository;
            _profileGraduationBusinessRules = profileGraduationBusinessRules;
        }

        public async Task<DeletedProfileGraduationResponse> Handle(DeleteProfileGraduationCommand request, CancellationToken cancellationToken)
        {
            ProfileGraduation? profileGraduation = await _profileGraduationRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _profileGraduationBusinessRules.ProfileGraduationShouldExistWhenSelected(profileGraduation);

            await _profileGraduationRepository.DeleteAsync(profileGraduation!);

            DeletedProfileGraduationResponse response = _mapper.Map<DeletedProfileGraduationResponse>(profileGraduation);
            return response;
        }
    }
}
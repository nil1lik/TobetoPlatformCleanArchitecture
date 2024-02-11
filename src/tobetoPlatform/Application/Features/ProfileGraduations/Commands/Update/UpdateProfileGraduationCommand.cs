using Application.Features.ProfileGraduations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileGraduations.Commands.Update;

public class UpdateProfileGraduationCommand : IRequest<UpdatedProfileGraduationResponse>
{
    public int Id { get; set; }
    public int GraduationId { get; set; }
    public int UserProfileId { get; set; }

    public class UpdateProfileGraduationCommandHandler : IRequestHandler<UpdateProfileGraduationCommand, UpdatedProfileGraduationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileGraduationRepository _profileGraduationRepository;
        private readonly ProfileGraduationBusinessRules _profileGraduationBusinessRules;

        public UpdateProfileGraduationCommandHandler(IMapper mapper, IProfileGraduationRepository profileGraduationRepository,
                                         ProfileGraduationBusinessRules profileGraduationBusinessRules)
        {
            _mapper = mapper;
            _profileGraduationRepository = profileGraduationRepository;
            _profileGraduationBusinessRules = profileGraduationBusinessRules;
        }

        public async Task<UpdatedProfileGraduationResponse> Handle(UpdateProfileGraduationCommand request, CancellationToken cancellationToken)
        {
            ProfileGraduation? profileGraduation = await _profileGraduationRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _profileGraduationBusinessRules.ProfileGraduationShouldExistWhenSelected(profileGraduation);
            profileGraduation = _mapper.Map(request, profileGraduation);

            await _profileGraduationRepository.UpdateAsync(profileGraduation!);

            UpdatedProfileGraduationResponse response = _mapper.Map<UpdatedProfileGraduationResponse>(profileGraduation);
            return response;
        }
    }
}
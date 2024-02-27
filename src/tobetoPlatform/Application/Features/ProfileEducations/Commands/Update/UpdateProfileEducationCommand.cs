using Application.Features.ProfileEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileEducations.Commands.Update;

public class UpdateProfileEducationCommand : IRequest<UpdatedProfileEducationResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationPathId { get; set; }

    public class UpdateProfileEducationCommandHandler : IRequestHandler<UpdateProfileEducationCommand, UpdatedProfileEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEducationRepository _profileEducationRepository;
        private readonly ProfileEducationBusinessRules _profileEducationBusinessRules;

        public UpdateProfileEducationCommandHandler(IMapper mapper, IProfileEducationRepository profileEducationRepository,
                                         ProfileEducationBusinessRules profileEducationBusinessRules)
        {
            _mapper = mapper;
            _profileEducationRepository = profileEducationRepository;
            _profileEducationBusinessRules = profileEducationBusinessRules;
        }

        public async Task<UpdatedProfileEducationResponse> Handle(UpdateProfileEducationCommand request, CancellationToken cancellationToken)
        {
            ProfileEducation? profileEducation = await _profileEducationRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileEducationBusinessRules.ProfileEducationShouldExistWhenSelected(profileEducation);
            profileEducation = _mapper.Map(request, profileEducation);

            await _profileEducationRepository.UpdateAsync(profileEducation!);

            UpdatedProfileEducationResponse response = _mapper.Map<UpdatedProfileEducationResponse>(profileEducation);
            return response;
        }
    }
}
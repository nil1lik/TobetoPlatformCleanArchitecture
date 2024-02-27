using Application.Features.ProfileClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileClasses.Commands.Create;

public class CreateProfileClassCommand : IRequest<CreatedProfileClassResponse>
{
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }
    public int EducationPathId { get; set; }

    public class CreateProfileClassCommandHandler : IRequestHandler<CreateProfileClassCommand, CreatedProfileClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileClassRepository _profileClassRepository;
        private readonly ProfileClassBusinessRules _profileClassBusinessRules;

        public CreateProfileClassCommandHandler(IMapper mapper, IProfileClassRepository profileClassRepository,
                                         ProfileClassBusinessRules profileClassBusinessRules)
        {
            _mapper = mapper;
            _profileClassRepository = profileClassRepository;
            _profileClassBusinessRules = profileClassBusinessRules;
        }

        public async Task<CreatedProfileClassResponse> Handle(CreateProfileClassCommand request, CancellationToken cancellationToken)
        {
            ProfileClass profileClass = _mapper.Map<ProfileClass>(request);

            await _profileClassRepository.AddAsync(profileClass);

            CreatedProfileClassResponse response = _mapper.Map<CreatedProfileClassResponse>(profileClass);
            return response;
        }
    }
}
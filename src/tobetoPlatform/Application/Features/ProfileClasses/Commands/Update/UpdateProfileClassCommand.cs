using Application.Features.ProfileClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileClasses.Commands.Update;

public class UpdateProfileClassCommand : IRequest<UpdatedProfileClassResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int CourseClassId { get; set; }
    public int EducationPathId { get; set; }

    public class UpdateProfileClassCommandHandler : IRequestHandler<UpdateProfileClassCommand, UpdatedProfileClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileClassRepository _profileClassRepository;
        private readonly ProfileClassBusinessRules _profileClassBusinessRules;

        public UpdateProfileClassCommandHandler(IMapper mapper, IProfileClassRepository profileClassRepository,
                                         ProfileClassBusinessRules profileClassBusinessRules)
        {
            _mapper = mapper;
            _profileClassRepository = profileClassRepository;
            _profileClassBusinessRules = profileClassBusinessRules;
        }

        public async Task<UpdatedProfileClassResponse> Handle(UpdateProfileClassCommand request, CancellationToken cancellationToken)
        {
            ProfileClass? profileClass = await _profileClassRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _profileClassBusinessRules.ProfileClassShouldExistWhenSelected(profileClass);
            profileClass = _mapper.Map(request, profileClass);

            await _profileClassRepository.UpdateAsync(profileClass!);

            UpdatedProfileClassResponse response = _mapper.Map<UpdatedProfileClassResponse>(profileClass);
            return response;
        }
    }
}
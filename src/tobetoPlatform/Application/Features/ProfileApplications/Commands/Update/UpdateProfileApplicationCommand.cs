using Application.Features.ProfileApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplications.Commands.Update;

public class UpdateProfileApplicationCommand : IRequest<UpdatedProfileApplicationResponse>
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }

    public class UpdateProfileApplicationCommandHandler : IRequestHandler<UpdateProfileApplicationCommand, UpdatedProfileApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationRepository _profileApplicationRepository;
        private readonly ProfileApplicationBusinessRules _profileApplicationBusinessRules;

        public UpdateProfileApplicationCommandHandler(IMapper mapper, IProfileApplicationRepository profileApplicationRepository,
                                         ProfileApplicationBusinessRules profileApplicationBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationRepository = profileApplicationRepository;
            _profileApplicationBusinessRules = profileApplicationBusinessRules;
        }

        public async Task<UpdatedProfileApplicationResponse> Handle(UpdateProfileApplicationCommand request, CancellationToken cancellationToken)
        {
            ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationBusinessRules.ProfileApplicationShouldExistWhenSelected(profileApplication);
            profileApplication = _mapper.Map(request, profileApplication);

            await _profileApplicationRepository.UpdateAsync(profileApplication!);

            UpdatedProfileApplicationResponse response = _mapper.Map<UpdatedProfileApplicationResponse>(profileApplication);
            return response;
        }
    }
}
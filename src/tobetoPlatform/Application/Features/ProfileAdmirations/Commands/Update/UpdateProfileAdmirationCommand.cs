using Application.Features.ProfileAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAdmirations.Commands.Update;

public class UpdateProfileAdmirationCommand : IRequest<UpdatedProfileAdmirationResponse>
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int EducationAdmirationId { get; set; }
    public int EducationPathId { get; set; }

    public class UpdateProfileAdmirationCommandHandler : IRequestHandler<UpdateProfileAdmirationCommand, UpdatedProfileAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAdmirationRepository _profileAdmirationRepository;
        private readonly ProfileAdmirationBusinessRules _profileAdmirationBusinessRules;

        public UpdateProfileAdmirationCommandHandler(IMapper mapper, IProfileAdmirationRepository profileAdmirationRepository,
                                         ProfileAdmirationBusinessRules profileAdmirationBusinessRules)
        {
            _mapper = mapper;
            _profileAdmirationRepository = profileAdmirationRepository;
            _profileAdmirationBusinessRules = profileAdmirationBusinessRules;
        }

        public async Task<UpdatedProfileAdmirationResponse> Handle(UpdateProfileAdmirationCommand request, CancellationToken cancellationToken)
        {
            ProfileAdmiration? profileAdmiration = await _profileAdmirationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileAdmirationBusinessRules.ProfileAdmirationShouldExistWhenSelected(profileAdmiration);
            profileAdmiration = _mapper.Map(request, profileAdmiration);

            await _profileAdmirationRepository.UpdateAsync(profileAdmiration!);

            UpdatedProfileAdmirationResponse response = _mapper.Map<UpdatedProfileAdmirationResponse>(profileAdmiration);
            return response;
        }
    }
}
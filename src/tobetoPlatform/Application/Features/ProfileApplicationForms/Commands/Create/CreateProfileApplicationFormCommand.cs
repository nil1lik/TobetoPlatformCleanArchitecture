using Application.Features.ProfileApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationForms.Commands.Create;

public class CreateProfileApplicationFormCommand : IRequest<CreatedProfileApplicationFormResponse>
{
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
    public bool ApprovalStatus { get; set; }
    public string Message { get; set; }

    public class CreateProfileApplicationFormCommandHandler : IRequestHandler<CreateProfileApplicationFormCommand, CreatedProfileApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
        private readonly ProfileApplicationFormBusinessRules _profileApplicationFormBusinessRules;

        public CreateProfileApplicationFormCommandHandler(IMapper mapper, IProfileApplicationFormRepository profileApplicationFormRepository,
                                         ProfileApplicationFormBusinessRules profileApplicationFormBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationFormRepository = profileApplicationFormRepository;
            _profileApplicationFormBusinessRules = profileApplicationFormBusinessRules;
        }

        public async Task<CreatedProfileApplicationFormResponse> Handle(CreateProfileApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationForm profileApplicationForm = _mapper.Map<ProfileApplicationForm>(request);

            await _profileApplicationFormRepository.AddAsync(profileApplicationForm);

            CreatedProfileApplicationFormResponse response = _mapper.Map<CreatedProfileApplicationFormResponse>(profileApplicationForm);
            return response;
        }
    }
}
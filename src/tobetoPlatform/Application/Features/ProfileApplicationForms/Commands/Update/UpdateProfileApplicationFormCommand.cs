using Application.Features.ProfileApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationForms.Commands.Update;

public class UpdateProfileApplicationFormCommand : IRequest<UpdatedProfileApplicationFormResponse>
{
    public int Id { get; set; }
    public int ApplicationFormId { get; set; }
    public string Name { get; set; }
    public bool ApprovalStatus { get; set; }
    public string Message { get; set; }

    public class UpdateProfileApplicationFormCommandHandler : IRequestHandler<UpdateProfileApplicationFormCommand, UpdatedProfileApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
        private readonly ProfileApplicationFormBusinessRules _profileApplicationFormBusinessRules;

        public UpdateProfileApplicationFormCommandHandler(IMapper mapper, IProfileApplicationFormRepository profileApplicationFormRepository,
                                         ProfileApplicationFormBusinessRules profileApplicationFormBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationFormRepository = profileApplicationFormRepository;
            _profileApplicationFormBusinessRules = profileApplicationFormBusinessRules;
        }

        public async Task<UpdatedProfileApplicationFormResponse> Handle(UpdateProfileApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationForm? profileApplicationForm = await _profileApplicationFormRepository.GetAsync(predicate: paf => paf.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationFormBusinessRules.ProfileApplicationFormShouldExistWhenSelected(profileApplicationForm);
            profileApplicationForm = _mapper.Map(request, profileApplicationForm);

            await _profileApplicationFormRepository.UpdateAsync(profileApplicationForm!);

            UpdatedProfileApplicationFormResponse response = _mapper.Map<UpdatedProfileApplicationFormResponse>(profileApplicationForm);
            return response;
        }
    }
}
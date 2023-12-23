using Application.Features.ProfileApplicationForms.Constants;
using Application.Features.ProfileApplicationForms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplicationForms.Commands.Delete;

public class DeleteProfileApplicationFormCommand : IRequest<DeletedProfileApplicationFormResponse>
{
    public int Id { get; set; }

    public class DeleteProfileApplicationFormCommandHandler : IRequestHandler<DeleteProfileApplicationFormCommand, DeletedProfileApplicationFormResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationFormRepository _profileApplicationFormRepository;
        private readonly ProfileApplicationFormBusinessRules _profileApplicationFormBusinessRules;

        public DeleteProfileApplicationFormCommandHandler(IMapper mapper, IProfileApplicationFormRepository profileApplicationFormRepository,
                                         ProfileApplicationFormBusinessRules profileApplicationFormBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationFormRepository = profileApplicationFormRepository;
            _profileApplicationFormBusinessRules = profileApplicationFormBusinessRules;
        }

        public async Task<DeletedProfileApplicationFormResponse> Handle(DeleteProfileApplicationFormCommand request, CancellationToken cancellationToken)
        {
            ProfileApplicationForm? profileApplicationForm = await _profileApplicationFormRepository.GetAsync(predicate: paf => paf.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationFormBusinessRules.ProfileApplicationFormShouldExistWhenSelected(profileApplicationForm);

            await _profileApplicationFormRepository.DeleteAsync(profileApplicationForm!);

            DeletedProfileApplicationFormResponse response = _mapper.Map<DeletedProfileApplicationFormResponse>(profileApplicationForm);
            return response;
        }
    }
}
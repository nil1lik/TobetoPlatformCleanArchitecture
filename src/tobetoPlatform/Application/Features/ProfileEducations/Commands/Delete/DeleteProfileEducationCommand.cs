using Application.Features.ProfileEducations.Constants;
using Application.Features.ProfileEducations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileEducations.Commands.Delete;

public class DeleteProfileEducationCommand : IRequest<DeletedProfileEducationResponse>
{
    public int Id { get; set; }

    public class DeleteProfileEducationCommandHandler : IRequestHandler<DeleteProfileEducationCommand, DeletedProfileEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileEducationRepository _profileEducationRepository;
        private readonly ProfileEducationBusinessRules _profileEducationBusinessRules;

        public DeleteProfileEducationCommandHandler(IMapper mapper, IProfileEducationRepository profileEducationRepository,
                                         ProfileEducationBusinessRules profileEducationBusinessRules)
        {
            _mapper = mapper;
            _profileEducationRepository = profileEducationRepository;
            _profileEducationBusinessRules = profileEducationBusinessRules;
        }

        public async Task<DeletedProfileEducationResponse> Handle(DeleteProfileEducationCommand request, CancellationToken cancellationToken)
        {
            ProfileEducation? profileEducation = await _profileEducationRepository.GetAsync(predicate: pe => pe.Id == request.Id, cancellationToken: cancellationToken);
            await _profileEducationBusinessRules.ProfileEducationShouldExistWhenSelected(profileEducation);

            await _profileEducationRepository.DeleteAsync(profileEducation!);

            DeletedProfileEducationResponse response = _mapper.Map<DeletedProfileEducationResponse>(profileEducation);
            return response;
        }
    }
}
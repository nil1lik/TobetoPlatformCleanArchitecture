using Application.Features.ProfileApplications.Constants;
using Application.Features.ProfileApplications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileApplications.Commands.Delete;

public class DeleteProfileApplicationCommand : IRequest<DeletedProfileApplicationResponse>
{
    public int Id { get; set; }

    public class DeleteProfileApplicationCommandHandler : IRequestHandler<DeleteProfileApplicationCommand, DeletedProfileApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileApplicationRepository _profileApplicationRepository;
        private readonly ProfileApplicationBusinessRules _profileApplicationBusinessRules;

        public DeleteProfileApplicationCommandHandler(IMapper mapper, IProfileApplicationRepository profileApplicationRepository,
                                         ProfileApplicationBusinessRules profileApplicationBusinessRules)
        {
            _mapper = mapper;
            _profileApplicationRepository = profileApplicationRepository;
            _profileApplicationBusinessRules = profileApplicationBusinessRules;
        }

        public async Task<DeletedProfileApplicationResponse> Handle(DeleteProfileApplicationCommand request, CancellationToken cancellationToken)
        {
            ProfileApplication? profileApplication = await _profileApplicationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileApplicationBusinessRules.ProfileApplicationShouldExistWhenSelected(profileApplication);

            await _profileApplicationRepository.DeleteAsync(profileApplication!);

            DeletedProfileApplicationResponse response = _mapper.Map<DeletedProfileApplicationResponse>(profileApplication);
            return response;
        }
    }
}
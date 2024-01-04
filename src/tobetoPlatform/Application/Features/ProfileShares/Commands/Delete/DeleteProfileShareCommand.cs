using Application.Features.ProfileShares.Constants;
using Application.Features.ProfileShares.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileShares.Commands.Delete;

public class DeleteProfileShareCommand : IRequest<DeletedProfileShareResponse>
{
    public int Id { get; set; }

    public class DeleteProfileShareCommandHandler : IRequestHandler<DeleteProfileShareCommand, DeletedProfileShareResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileShareRepository _profileShareRepository;
        private readonly ProfileShareBusinessRules _profileShareBusinessRules;

        public DeleteProfileShareCommandHandler(IMapper mapper, IProfileShareRepository profileShareRepository,
                                         ProfileShareBusinessRules profileShareBusinessRules)
        {
            _mapper = mapper;
            _profileShareRepository = profileShareRepository;
            _profileShareBusinessRules = profileShareBusinessRules;
        }

        public async Task<DeletedProfileShareResponse> Handle(DeleteProfileShareCommand request, CancellationToken cancellationToken)
        {
            ProfileShare? profileShare = await _profileShareRepository.GetAsync(predicate: ps => ps.Id == request.Id, cancellationToken: cancellationToken);
            await _profileShareBusinessRules.ProfileShareShouldExistWhenSelected(profileShare);

            await _profileShareRepository.DeleteAsync(profileShare!);

            DeletedProfileShareResponse response = _mapper.Map<DeletedProfileShareResponse>(profileShare);
            return response;
        }
    }
}
using Application.Features.ProfileClasses.Constants;
using Application.Features.ProfileClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileClasses.Commands.Delete;

public class DeleteProfileClassCommand : IRequest<DeletedProfileClassResponse>
{
    public int Id { get; set; }

    public class DeleteProfileClassCommandHandler : IRequestHandler<DeleteProfileClassCommand, DeletedProfileClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileClassRepository _profileClassRepository;
        private readonly ProfileClassBusinessRules _profileClassBusinessRules;

        public DeleteProfileClassCommandHandler(IMapper mapper, IProfileClassRepository profileClassRepository,
                                         ProfileClassBusinessRules profileClassBusinessRules)
        {
            _mapper = mapper;
            _profileClassRepository = profileClassRepository;
            _profileClassBusinessRules = profileClassBusinessRules;
        }

        public async Task<DeletedProfileClassResponse> Handle(DeleteProfileClassCommand request, CancellationToken cancellationToken)
        {
            ProfileClass? profileClass = await _profileClassRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _profileClassBusinessRules.ProfileClassShouldExistWhenSelected(profileClass);

            await _profileClassRepository.DeleteAsync(profileClass!);

            DeletedProfileClassResponse response = _mapper.Map<DeletedProfileClassResponse>(profileClass);
            return response;
        }
    }
}
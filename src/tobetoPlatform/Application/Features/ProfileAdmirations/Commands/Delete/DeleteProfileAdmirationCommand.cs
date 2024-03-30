using Application.Features.ProfileAdmirations.Constants;
using Application.Features.ProfileAdmirations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAdmirations.Commands.Delete;

public class DeleteProfileAdmirationCommand : IRequest<DeletedProfileAdmirationResponse>
{
    public int Id { get; set; }

    public class DeleteProfileAdmirationCommandHandler : IRequestHandler<DeleteProfileAdmirationCommand, DeletedProfileAdmirationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAdmirationRepository _profileAdmirationRepository;
        private readonly ProfileAdmirationBusinessRules _profileAdmirationBusinessRules;

        public DeleteProfileAdmirationCommandHandler(IMapper mapper, IProfileAdmirationRepository profileAdmirationRepository,
                                         ProfileAdmirationBusinessRules profileAdmirationBusinessRules)
        {
            _mapper = mapper;
            _profileAdmirationRepository = profileAdmirationRepository;
            _profileAdmirationBusinessRules = profileAdmirationBusinessRules;
        }

        public async Task<DeletedProfileAdmirationResponse> Handle(DeleteProfileAdmirationCommand request, CancellationToken cancellationToken)
        {
            ProfileAdmiration? profileAdmiration = await _profileAdmirationRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileAdmirationBusinessRules.ProfileAdmirationShouldExistWhenSelected(profileAdmiration);

            await _profileAdmirationRepository.DeleteAsync(profileAdmiration!);

            DeletedProfileAdmirationResponse response = _mapper.Map<DeletedProfileAdmirationResponse>(profileAdmiration);
            return response;
        }
    }
}
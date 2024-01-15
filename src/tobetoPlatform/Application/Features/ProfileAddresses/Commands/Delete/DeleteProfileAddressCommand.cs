using Application.Features.ProfileAddresses.Constants;
using Application.Features.ProfileAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProfileAddresses.Commands.Delete;

public class DeleteProfileAddressCommand : IRequest<DeletedProfileAddressResponse>
{
    public int Id { get; set; }

    public class DeleteProfileAddressCommandHandler : IRequestHandler<DeleteProfileAddressCommand, DeletedProfileAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileAddressRepository _profileAddressRepository;
        private readonly ProfileAddressBusinessRules _profileAddressBusinessRules;

        public DeleteProfileAddressCommandHandler(IMapper mapper, IProfileAddressRepository profileAddressRepository,
                                         ProfileAddressBusinessRules profileAddressBusinessRules)
        {
            _mapper = mapper;
            _profileAddressRepository = profileAddressRepository;
            _profileAddressBusinessRules = profileAddressBusinessRules;
        }

        public async Task<DeletedProfileAddressResponse> Handle(DeleteProfileAddressCommand request, CancellationToken cancellationToken)
        {
            ProfileAddress? profileAddress = await _profileAddressRepository.GetAsync(predicate: pa => pa.Id == request.Id, cancellationToken: cancellationToken);
            await _profileAddressBusinessRules.ProfileAddressShouldExistWhenSelected(profileAddress);

            await _profileAddressRepository.DeleteAsync(profileAddress!);

            DeletedProfileAddressResponse response = _mapper.Map<DeletedProfileAddressResponse>(profileAddress);
            return response;
        }
    }
}